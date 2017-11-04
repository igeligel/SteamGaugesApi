using System.Net.Http;
using Newtonsoft.Json;
using SteamGaugesApi.Core.Models;

namespace SteamGaugesApi.Core
{
    public class Client
    {
        private readonly HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient();
        }

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public SteamGaugesResponse Get()
        {
            var responseContent = _httpClient.GetAsync("https://steamgaug.es/api/v2").Result
                .Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SteamGaugesResponse>(responseContent);
        }
    }
}
