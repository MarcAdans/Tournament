using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryMoviesByIdHandler : IRequestHandler<QueryMoviesByIdRequest, ImdbMovie>
    {
        private readonly IImdbMovieConnectorApi connectorApi;

        public QueryMoviesByIdHandler(IImdbMovieConnectorApi connectorApi)
        {
            this.connectorApi = connectorApi;
        }

        public async Task<ImdbMovie> Handle(QueryMoviesByIdRequest request, CancellationToken cancellationToken)
        {
            return await connectorApi.GetMovieAsync(request.Id);
        }
    }
}