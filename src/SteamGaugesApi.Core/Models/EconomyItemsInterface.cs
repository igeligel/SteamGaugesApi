using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class EconomyItemsInterFace
    {
        [JsonProperty(PropertyName = "440")]
        public TeamFortressEconomyItemsInterface
            TeamFortressEconomyItemsInterface { get; set; }

        [JsonProperty(PropertyName = "570")]
        public DotaEconomyInterface DotaEconomyInterface { get; set; }

        [JsonProperty(PropertyName = "730")]
        public CounterStrikeGlobalOffensiveEconomyInterface
            CounterStrikeGlobalOffensiveEconomyInterface { get; set; }
    }
}
