using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class SteamGaugesResponse
    {
        [JsonProperty(PropertyName = "ISteamClient")]
        public SteamClientInterface SteamClientInterface { get; set; }

        [JsonProperty(PropertyName = "SteamCommunity")]
        public SteamCommunity SteamCommunity { get; set; }

        [JsonProperty(PropertyName = "SteamStore")]
        public SteamStore SteamStore { get; set; }

        [JsonProperty(PropertyName = "ISteamUser")]
        public SteamUserInterface SteamUserInterface { get; set; }

        [JsonProperty(PropertyName = "ITFSystem_440")]
        public TeamFortressSystemInterface TeamFortressSystemInterface
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "IEconItems")]
        public EconomyItemsInterFace EconomyItemsInterFace { get; set; }

        [JsonProperty(PropertyName = "ISteamGameCoordinator")]
        public SteamGameCoordinationInterface SteamGameCoordinationInterface
        {
            get;
            set;
        }
    }
}
