using Newtonsoft.Json;

namespace discogsharp.Domain;

public class MasterSearchResult : SearchResult
{
    [JsonProperty("style")]
    public List<string>? Styles { get; set; }

    [JsonProperty("format")]
    public List<string>? Formats { get; set; }

    public string? Country { get; set; }

    [JsonProperty("label")]
    public List<string>? Labels { get; set; }

    public string? Catno { get; set; }
    public int? Year { get; set; }

    [JsonProperty("genre")]
    public List<string>? Genres { get; set; }
}