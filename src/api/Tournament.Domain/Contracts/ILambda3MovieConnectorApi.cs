using System.Collections.Generic;
using System.Threading.Tasks;
using Tournament.Domain.MovieContext.Contracts;

namespace Tournament.Domain.Contracts
{
    public interface ILambda3MovieConnectorApi
    {
        Task<IEnumerable<IMovie>> GetMoviesAsync();
    }
}