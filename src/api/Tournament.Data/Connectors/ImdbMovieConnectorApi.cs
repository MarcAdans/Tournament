using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Tournament.CrossCutting;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Data.Connectors
{
    public class ImdbMovieConnectorApi : IImdbMovieConnectorApi
    {
        private readonly ImdbMovieOptions options;

        public ImdbMovieConnectorApi(IOptionsSnapshot<ImdbMovieOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<ImdbMovie> GetMoviesAsync(string id)
        {
            return await HttpClientService.GetAsync<ImdbMovie>(options.FindByIdEndPoint(id));
        }
    }
}