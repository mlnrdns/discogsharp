using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class ReleaseRatingInFolder
    {
        public int? ReleaseId { get; set; }
        public int? FolderId { get; set; }

        [JsonProperty("rating")]
        public int? Rating { get; set; }
    }
}