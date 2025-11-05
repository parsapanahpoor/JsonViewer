namespace JsonViewerComponent.Models;

public class JsonStats
{
    public int TotalProperties { get; set; }
    public int ObjectCount { get; set; }
    public int ArrayCount { get; set; }
    public int ArrayItems { get; set; }
    public int StringCount { get; set; }
    public int NumberCount { get; set; }
    public int BooleanCount { get; set; }
    public int NullCount { get; set; }
    public int MaxDepth { get; set; }
    public long RawSize { get; set; }
    public long FormattedSize { get; set; }
    public double AvgPropertiesPerObject { get; set; }
    public double AvgArrayLength { get; set; }
    public int TotalStringLength { get; set; }
    public int MaxStringLength { get; set; }
    public int TotalNumberLength { get; set; }
    public Dictionary<string, int> PropertyCounts { get; set; } = new Dictionary<string, int>();

}
