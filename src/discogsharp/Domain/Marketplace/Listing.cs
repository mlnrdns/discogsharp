using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Listing : Resource
    {
        [JsonProperty("allow_offers")]
        public bool AllowOffers { get; set; }

        public string Comments { get; set; }
        public Condition Condition { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("format_quantity")]
        public int FormatQuantity { get; set; }

        [JsonProperty("in_cart")]
        public bool InCart { get; set; }

        public string Location { get; set; }

        [JsonProperty("original_price")]
        public Price OriginalPrice { get; set; }

        [JsonProperty("original_shipping_price")]
        public Price OriginalShippingPrice { get; set; }

        public DateTime Posted { get; set; }
        public Price Price { get; set; }

        public Seller Seller { get; set; }

        [JsonProperty("shipping_price")]
        public Price ShippingPrice { get; set; }

        [JsonProperty("ships_from")]
        public string ShipsFrom { get; set; }

        [JsonProperty("sleeve_condition")]
        public SleeveCondition SleeveCondition { get; set; }

        public string Status { get; set; }

        public float? Weight { get; set; }
    }
}
