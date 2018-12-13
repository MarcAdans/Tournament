using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournament.CrossCutting;
using Tournament.Domain.Contracts;
using Tournament.Domain.MovieContext.Contracts;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Data.Connectors
{
    public class Lambda3MovieConnectorApi : ILambda3MovieConnectorApi
    {
        private readonly Lambda3MovieOptions options;

        public Lambda3MovieConnectorApi(IOptionsSnapshot<Lambda3MovieOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<IEnumerable<IMovie>> GetMoviesAsync()
        {
            return await HttpClientService.GetAsync<IEnumerable<Movie>>(options.BaseEndpoint);
        }
    }
}