using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class ReleaseRatingInFolder
    {
        public int? FolderId { get; set; }

        [JsonProperty("rating")]
        public int? Rating { get; set; }

        public int? ReleaseId { get; set; }
    }
}
