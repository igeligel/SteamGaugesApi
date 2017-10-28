using Newtonsoft.Json;
using SteamGaugesApi.Core.Interfaces;

namespace SteamGaugesApi.Core.Models
{
    public class SteamClientInterface : ISteamInterfaceBase
    {
        [JsonProperty(PropertyName = "online")]
        public bool Online { get; set; }
    }
}
