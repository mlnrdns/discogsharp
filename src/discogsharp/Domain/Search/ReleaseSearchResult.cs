using Newtonsoft.Json;

namespace discogsharp.Domain;

public class ReleaseSearchResult : MasterSearchResult
{
    [JsonProperty("barcode")]
    public List<string>? Barcodes { get; set; }
}
