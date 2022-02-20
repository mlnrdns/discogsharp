using Newtonsoft.Json;

namespace discogsharp.Domain;

public class Artist : Resource
{
    public List<Alias> Aliases { get; set; }
    public DataQuality DataQuality { get; set; }
    public List<Member> Members { get; set; }
    public string Name { get; set; }

    [JsonProperty("namevariations")]
    public List<string> NameVariations { get; set; }

    public string Profile { get; set; }
    public string? RealName { get; set; }
    public string ReleasesUrl { get; set; }
    public string Uri { get; set; }
    public List<string> Urls { get; set; }
}
