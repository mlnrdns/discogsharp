namespace discogsharp.Domain;

public abstract class SearchResult : Resource
{
    public ResourceType Type { get; set; }
    public string? Thumb { get; set; }
    public string? Title { get; set; }
    public string? Uri { get; set; }
}