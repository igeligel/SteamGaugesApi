using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class WarScore
    {
        [JsonProperty(PropertyName = "side")]
        public int Side { get; set; }

        [JsonProperty(PropertyName = "score")]
        public Score Score { get; set; }
    }

    public class Score
    {
        [JsonProperty(PropertyName = "low")]
        public int Low { get; set; }

        [JsonProperty(PropertyName = "high")]
        public int High { get; set; }

        [JsonProperty(PropertyName = "unsigned")]
        public bool Unsigned { get; set; }
    }
}
