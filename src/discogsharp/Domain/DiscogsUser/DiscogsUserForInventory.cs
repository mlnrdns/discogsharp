using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class DiscogsUserForInventory : Resource
    {
        [JsonProperty("username")]
        public string Username { get; set; } = null!;
    }
}
