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
                var response = await client.GetAsync(urlApi)
                                           .ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode
                     ? JsonConvert.DeserializeObject<T>(
                         await response.Content.ReadAsStringAsync()
                                               .ConfigureAwait(false))
                     : default(T);
            }
        }
    }
}