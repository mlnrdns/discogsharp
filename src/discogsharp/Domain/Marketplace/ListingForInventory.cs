using Newtonsoft.Json;

namespace discogsharp.Domain;

public class ListingForInventory : Resource
{
    [JsonProperty("allow_offers")]
    public bool AllowOffers { get; set; }

    public bool Audio { get; set; }
    public string Comments { get; set; }
    public Condition Condition { get; set; }
    public DateTime Posted { get; set; }
    public Price Price { get; set; }
    public ReleaseForInventory Release { get; set; }
    public DiscogsUserForInventory Seller { get; set; }

    [JsonProperty("ships_from")]
    public string ShipsFrom { get; set; }

    [JsonProperty("sleeve_condition")]
    public SleeveCondition SleeveCondition { get; set; }

    public string Status { get; set; }
    public string Uri { get; set; }
}
