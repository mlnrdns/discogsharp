using Newtonsoft.Json;

namespace discogsharp.Domain;

public class Field
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("position")]
    public int Position { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("public")]
    public bool IsPublic { get; set; }
}