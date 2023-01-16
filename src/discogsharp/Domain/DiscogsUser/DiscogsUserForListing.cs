using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class DiscogsUserForListing : Resource
    {
        [JsonProperty("username")]
        public string Username { get; set; } = null!;
    }
}
