using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tournament.CrossCutting
{
    public static class HttpClientService
    {
        public static async Task<T> GetAsync<T>(string urlApi)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlApi);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<T>(data);

                return result;
            }
        }
    }
}