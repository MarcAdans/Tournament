using System.Collections.Generic;
using System.Threading.Tasks;
using Tournament.Domain.Lambda3Context.Models;

namespace Tournament.Domain.Contracts
{
    public interface ILambda3MovieConnectorApi
    {
        Task<IEnumerable<Lambda3Movie>> GetMoviesAsync();
    }
}