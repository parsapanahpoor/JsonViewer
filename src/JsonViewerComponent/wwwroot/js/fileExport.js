/**
 * دانلود فایل از محتوای متنی
 * @param {string} filename - نام فایل
 * @param {string} content - محتوای فایل
 * @param {string} contentType - نوع محتوا (MIME type)
 */
window.downloadFile = function (filename, content, contentType) {
    const blob = new Blob([content], { type: contentType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
};
