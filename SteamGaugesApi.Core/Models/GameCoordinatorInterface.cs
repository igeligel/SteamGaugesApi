using Newtonsoft.Json;

namespace SteamGaugesApi.Core.Models
{
    public class GameCoordinatorInterface
    {
        [JsonProperty(PropertyName = "online")]
        public bool Online { get; set; }

        [JsonProperty(PropertyName = "schema")]
        public string Schema { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "stats")]
        public Statistics Statistics { get; set; }
    }

    public class Statistics
    {
        [JsonProperty(PropertyName = "warScore")]
        public WarScore WarScore { get; set; }

        [JsonProperty(PropertyName = "players_searching")]
        public int? PlayersSearching { get; set; }

        [JsonProperty(PropertyName = "average_wait")]
        public int? AverageWaitTime { get; set; }

        [JsonProperty(PropertyName = "ongoing_matches")]
        public int? OnGoingMatches { get; set; }

        [JsonProperty(PropertyName = "servers_available")]
        public int? ServersAvailable { get; set; }

        [JsonProperty(PropertyName = "servers_online")]
        public int? ServersOnline { get; set; }

        [JsonProperty(PropertyName = "menu_url")]
        public string MenuUrl { get; set; }

        [JsonProperty(PropertyName = "players_online")]
        public int? PlayersOnline { get; set; }
    }
}
