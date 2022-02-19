using Newtonsoft.Json;

namespace discogsharp.Domain;

public abstract class Resource
{
    [JsonProperty("id")]
    public int Id { get; set; }
    public string ResourceUrl { get; set; } = null!;
}