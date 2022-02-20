using Newtonsoft.Json;

namespace discogsharp.Domain;

public class FieldList
{
    [JsonProperty("fields")]
    public List<Field>? Fields { get; set; }
}
