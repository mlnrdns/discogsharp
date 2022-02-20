using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class ReleaseRatingByUser
    {
        [JsonProperty("rating")]
        public int? Rating { get; set; }

        public int? ReleaseId { get; set; }
        public string? Username { get; set; }
    }
}
