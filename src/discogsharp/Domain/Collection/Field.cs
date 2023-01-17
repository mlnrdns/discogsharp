using Newtonsoft.Json;

namespace discogsharp.Domain;

public class Field
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("public")]
    public bool IsPublic { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}
