using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class TeamFortressSystemInterface
    {
        [JsonProperty(PropertyName = "stress_test")]
        public bool StressTest { get; set; }
    }
}
