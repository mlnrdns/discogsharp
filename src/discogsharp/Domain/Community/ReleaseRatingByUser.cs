using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class ReleaseRatingByUser
    {
        public int? ReleaseId { get; set; }
        public string? Username { get; set; }
        [JsonProperty("rating")]
        public int? Rating { get; set; }
    }
}