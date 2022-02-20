using Newtonsoft.Json;

namespace discogsharp.Domain;

public class Folder : Resource
{
    public int Count { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}
