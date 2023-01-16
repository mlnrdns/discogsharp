using Newtonsoft.Json;

namespace discogsharp.Domain;

public class ReleaseForListing : Resource
{
    [JsonProperty("catalog_number")]
    public string CatalogNumber { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string Artist { get; set; }
    public string Title { get; set; }
    public string Format { get; set; }
    public string Thumbnail { get; set; }
    
}