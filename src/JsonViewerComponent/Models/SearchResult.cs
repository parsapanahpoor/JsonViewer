namespace JsonViewerComponent.Models;

public class SearchResult
{
    public int MatchCount { get; set; }
    public int CurrentMatchIndex { get; set; }
    public bool HasMatches => MatchCount > 0;
    public bool CanNavigateNext => CurrentMatchIndex < MatchCount - 1;
    public bool CanNavigatePrevious => CurrentMatchIndex > 0;
}
