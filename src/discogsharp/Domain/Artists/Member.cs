using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Member : Resource
    {
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool IsActive { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}