using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.TeamContext.Requests;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Handlers
{
    public class QueryMoviesHandler : IRequestHandler<QueryMoviesRequest, IEnumerable<Movie>>
    {
        public async Task<IEnumerable<Movie>> Handle(QueryMoviesRequest request, CancellationToken cancellationToken)
        {
            const string urlApi = "https://copadosfilmes.azurewebsites.net/api/filmes" 

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlApi);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<IEnumerable<Movie>>(data);

                return result;
            }
        }
    }
}