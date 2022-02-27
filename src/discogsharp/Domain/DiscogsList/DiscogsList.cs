using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class DiscogsList : Resource
    {
        public DateTime DateAdded { get; set; }
        public DateTime? DateChanged { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [JsonProperty("public")]
        public bool IsPublic { get; set; }

        [JsonProperty("items")]
        public List<DiscogsListEntity>? Items { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("uri")]
        public string Uri { get; set; } = null!;

        [JsonProperty("user")]
        public DiscogsUserForList User { get; set; } = null!;
    }
}
