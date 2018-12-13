using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.TeamContext.Requests;
using Tournament.Domain.Contracts;
using Tournament.Domain.MovieContext.Contracts;

namespace Tournament.Application.ReadContext.MovieContext.Handlers
{
    public class QueryMoviesHandler : IRequestHandler<QueryMoviesRequest, IEnumerable<IMovie>>
    {
        private readonly ILambda3MovieConnectorApi connectorApi;

        public QueryMoviesHandler(ILambda3MovieConnectorApi connectorApi)
        {
            this.connectorApi = connectorApi;
        }

        public async Task<IEnumerable<IMovie>> Handle(QueryMoviesRequest request, CancellationToken cancellationToken)
        {
            return await connectorApi.GetMoviesAsync();
        }
    }
}