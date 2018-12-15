using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.CrossCutting;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Data.Connectors
{
    public class ImdbMovieConnectorApi : IImdbMovieConnectorApi
    {
        private readonly ImdbMovieOptions options;

        public ImdbMovieConnectorApi(IOptionsSnapshot<ImdbMovieOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<ImdbMovie> GetMovieAsync(string id) =>
            await HttpClientService
                .GetAsync<ImdbMovie>(options.FindByIdEndPoint(id))
                .ConfigureAwait(false);

        public async Task UpdateMovieAsync(Movie movie)
        {
            var imdb = await HttpClientService
                .GetAsync<ImdbMovie>(options.FindByIdEndPoint(movie.Id))
                .ConfigureAwait(false);

            movie.Poster = imdb.Poster;
        }

        public async Task UpdateMoviesAsync(IEnumerable<Movie> movies)
        {
            var tasks = movies.Select(UpdateMovieAsync);
            await Task.WhenAll(tasks)
                      .ConfigureAwait(false);
        }
    }
}