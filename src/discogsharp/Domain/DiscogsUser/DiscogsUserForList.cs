using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class DiscogsUserForList : Resource
    {
        public string? AvatarUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; } = null!;
    }
}
