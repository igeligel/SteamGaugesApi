using Newtonsoft.Json;
using SteamGaugesApi.Core.Converter;
using SteamGaugesApi.Core.Interfaces;

namespace SteamGaugesApi.Core.Models
{
    public class SteamClientInterface : ISteamInterfaceBase
    {
        [JsonProperty(PropertyName = "online")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Online { get; set; }
    }
}
