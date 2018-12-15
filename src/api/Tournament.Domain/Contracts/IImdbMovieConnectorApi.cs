using System.Collections.Generic;
using System.Threading.Tasks;
using Tournament.Domain.ImdbContext.Models;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Domain.Contracts
{
    public interface IImdbMovieConnectorApi
    {
        Task<ImdbMovie> GetMovieAsync(string id);

        Task UpdateMoviesAsync(IEnumerable<Movie> movies);
    }
}