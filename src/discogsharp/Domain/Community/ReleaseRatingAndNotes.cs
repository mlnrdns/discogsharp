using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace discogsharp.Domain;

public class ReleaseRatingAndNotes
{
    [JsonProperty("notes")]
    public string? Notes { get; set; }

    [JsonProperty("rating")]
    public int? Rating { get; set; }

    public int ReleaseId { get; set; }
}
