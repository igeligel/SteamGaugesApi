using Newtonsoft.Json;
using SteamGaugesApi.Core.Converter;
using SteamGaugesApi.Core.Interfaces;

namespace SteamGaugesApi.Core.Models
{
    public class SteamUserInterface : ISteamInterface
    {
        [JsonProperty(PropertyName = "online")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Online { get; set; }

        [JsonProperty(PropertyName = "time")]
        public int ResponseTime { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
