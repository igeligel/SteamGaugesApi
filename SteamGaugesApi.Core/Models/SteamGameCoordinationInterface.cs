using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class SteamGameCoordinationInterface
    {
        [JsonProperty(PropertyName = "440")]
        public GameCoordinatorInterface TeamFortressGameCoordinatorInterface
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "570")]
        public GameCoordinatorInterface DotaGameCoordinatorInterface
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "730")]
        public GameCoordinatorInterface
            CounterStrikeGlobalOffensiveGameCoordinatorInterface { get; set; }
    }
}
