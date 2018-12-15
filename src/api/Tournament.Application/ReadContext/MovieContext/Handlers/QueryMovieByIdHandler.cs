using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryMovieByIdHandler : IRequestHandler<QueryMovieByIdRequest, ImdbMovie>
    {
        private readonly IImdbMovieConnectorApi connectorApi;

        public QueryMovieByIdHandler(IImdbMovieConnectorApi connectorApi)
        {
            this.connectorApi = connectorApi;
        }

        public async Task<ImdbMovie> Handle(QueryMovieByIdRequest request, CancellationToken cancellationToken)
        {
            return await connectorApi.GetMovieAsync(request.Id);
        }
    }
}