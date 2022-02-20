using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Member : Resource
    {
        [JsonProperty("active")]
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
