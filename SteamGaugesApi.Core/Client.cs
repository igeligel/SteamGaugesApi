using System.Net.Http;
using Newtonsoft.Json;
using SteamGaugesApi.Core.Models;

namespace SteamGaugesApi.Core
{
    public class Client
    {
        public SteamGaugesResponse Get()
        {
            var httpClient = new HttpClient();
            var responseContent = httpClient.GetAsync("https://steamgaug.es/api/v2").Result
                .Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SteamGaugesResponse>(responseContent);
        }
    }
}
