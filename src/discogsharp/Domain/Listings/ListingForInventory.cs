using Newtonsoft.Json;

namespace discogsharp.Domain;

public class ListingForInventory : Resource
{
    public string Status { get; set; }
    public Price Price { get; set; }
    [JsonProperty("allow_offers")]
    public bool AllowOffers { get; set; }
    [JsonProperty("sleeve_condition")]
    public string SleeveCondition { get; set; }
    public string Condition { get; set; }
    public DateTime Posted { get; set; }
    [JsonProperty("ships_from")]
    public string ShipsFrom { get; set; }
    public string Uri { get; set; }
    public string Comments { get; set; }
    public DiscogsUserForListing Seller { get; set; }
    public ReleaseForListing Release { get; set; }
    public bool Audio { get; set; }
    
    
}