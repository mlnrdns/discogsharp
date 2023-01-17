using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class ListingToAddOrUpdate
    {
        [JsonProperty("allow_offers")]
        public bool? AllowOffers { get; set; }

        [JsonProperty("comments")]
        public string? Comments { get; set; }

        [JsonProperty("condition")]
        public Condition? Condition { get; set; }

        [JsonProperty("external_id")]
        public string? ExternalId { get; set; }

        [JsonProperty("format_quantity")]
        public float? FormatQuantity { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("price")]
        public float? Price { get; set; }

        [JsonProperty("release_id")]
        public long ReleaseId { get; set; }

        [JsonProperty("sleeve_condition")]
        public SleeveCondition? SleeveCondition { get; set; }

        [JsonProperty("status")]
        public Status? Status { get; set; }

        [JsonProperty("weight")]
        public float? Weight { get; set; }
    }
}
