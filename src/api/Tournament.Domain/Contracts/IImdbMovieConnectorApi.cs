using System.Threading.Tasks;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Domain.Contracts
{
    public interface IImdbMovieConnectorApi
    {
        Task<ImdbMovie> GetMoviesAsync(string id);
    }
}