using Newtonsoft.Json;

namespace discogsharp.Domain;

public abstract class Resource
{
    [JsonProperty("id")]
    public long Id { get; set; }

    public string ResourceUrl { get; set; } = null!;
}
