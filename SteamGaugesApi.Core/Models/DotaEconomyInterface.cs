using Newtonsoft.Json;
using SteamGaugesApi.Core.Interfaces;

namespace SteamGaugesApi.Core.Models
{
    public class DotaEconomyInterface : ISteamInterface
    {
        [JsonProperty(PropertyName = "online")]
        public bool Online { get; set; }

        [JsonProperty(PropertyName = "time")]
        public int ResponseTime { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
