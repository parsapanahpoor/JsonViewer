using Microsoft.JSInterop;
using System.Text;

namespace JsonViewerComponent.Services;

public interface IOptimizedFileDownloadService
{
    Task DownloadFileAsync(string fileName, string content, string contentType = "text/plain");
    Task DownloadLargeFileAsync(string fileName, string content, string contentType = "text/plain", int chunkSize = 1024 * 1024);
}

public class OptimizedFileDownloadService : IOptimizedFileDownloadService
{
    private readonly IJSRuntime _jsRuntime;

    public OptimizedFileDownloadService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    // برای فایل‌های کوچک (< 5MB)
    public async Task DownloadFileAsync(string fileName, string content, string contentType = "text/plain")
    {
        var bytes = Encoding.UTF8.GetBytes(content);
        var base64 = Convert.ToBase64String(bytes);

        await _jsRuntime.InvokeVoidAsync("eval", $@"
                (function() {{
                    const base64 = '{base64}';
                    const binary = atob(base64);
                    const bytes = new Uint8Array(binary.length);
                    for (let i = 0; i < binary.length; i++) {{
                        bytes[i] = binary.charCodeAt(i);
                    }}
                    const blob = new Blob([bytes], {{ type: '{contentType}' }});
                    const url = URL.createObjectURL(blob);
                    const a = document.createElement('a');
                    a.href = url;
                    a.download = '{fileName}';
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    URL.revokeObjectURL(url);
                }})();
            ");
    }

    // برای فایل‌های بزرگ (> 5MB) - با Chunking
    public async Task DownloadLargeFileAsync(string fileName, string content, string contentType = "text/plain", int chunkSize = 1024 * 1024)
    {
        var bytes = Encoding.UTF8.GetBytes(content);
        var totalChunks = (int)Math.Ceiling((double)bytes.Length / chunkSize);

        // ایجاد فایل در browser
        await _jsRuntime.InvokeVoidAsync("eval", $@"
                window._fileChunks = [];
                window._fileName = '{fileName}';
                window._contentType = '{contentType}';
                window._totalChunks = {totalChunks};
            ");

        // ارسال chunks
        for (int i = 0; i < totalChunks; i++)
        {
            var start = i * chunkSize;
            var length = Math.Min(chunkSize, bytes.Length - start);
            var chunk = new byte[length];
            Array.Copy(bytes, start, chunk, 0, length);
            var base64Chunk = Convert.ToBase64String(chunk);

            await _jsRuntime.InvokeVoidAsync("eval", $@"
                    window._fileChunks.push('{base64Chunk}');
                ");
        }

        // ترکیب و دانلود
        await _jsRuntime.InvokeVoidAsync("eval", $@"
                (function() {{
                    const chunks = window._fileChunks;
                    const fileName = window._fileName;
                    const contentType = window._contentType;
                    
                    const arrays = chunks.map(chunk => {{
                        const binary = atob(chunk);
                        const bytes = new Uint8Array(binary.length);
                        for (let i = 0; i < binary.length; i++) {{
                            bytes[i] = binary.charCodeAt(i);
                        }}
                        return bytes;
                    }});
                    
                    const totalLength = arrays.reduce((sum, arr) => sum + arr.length, 0);
                    const combined = new Uint8Array(totalLength);
                    let offset = 0;
                    for (const arr of arrays) {{
                        combined.set(arr, offset);
                        offset += arr.length;
                    }}
                    
                    const blob = new Blob([combined], {{ type: contentType }});
                    const url = URL.createObjectURL(blob);
                    const a = document.createElement('a');
                    a.href = url;
                    a.download = fileName;
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    URL.revokeObjectURL(url);
                    
                    delete window._fileChunks;
                    delete window._fileName;
                    delete window._contentType;
                    delete window._totalChunks;
                }})();
            ");
    }
}
