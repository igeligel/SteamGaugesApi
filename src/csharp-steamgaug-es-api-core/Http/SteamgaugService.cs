using System.Net.Http;
using System.Threading.Tasks;
using csharp_steamgaug_es_api_core.Models.Http;
using Newtonsoft.Json;

namespace csharp_steamgaug_es_api_core.Http
{
    public static class SteamgaugService
    {
        public static async Task<string> GetJsonData()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("https://steamgaug.es/api/v2"))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                if (result != null)
                {
                    SteamgaugResponseModel responseModel = JsonConvert.DeserializeObject<SteamgaugResponseModel>(result);
                    return result;
                }
            }
            return null;
        }
    }
}
