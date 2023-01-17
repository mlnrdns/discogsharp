using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Seller : Resource
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public string Payment { get; set; }
        public string Shipping { get; set; }
        public Stats Stats { get; set; }
        public string Url { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
