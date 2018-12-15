using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryMovieByIdHandler : IRequestHandler<QueryMovieByIdRequest, ImdbMovie>
    {
        private readonly IImdbMovieConnectorApi connectorApi;
        private readonly ILogger<QueryMovieByIdHandler> logger;

        public QueryMovieByIdHandler(IImdbMovieConnectorApi connectorApi,
            ILogger<QueryMovieByIdHandler> logger)
        {
            this.connectorApi = connectorApi;
            this.logger = logger;
        }

        public async Task<ImdbMovie> Handle(QueryMovieByIdRequest request, CancellationToken cancellationToken)
        {
            logger.LogTrace($"Buscando informações do file {request.Id}");
            return await connectorApi.GetMovieAsync(request.Id);
        }
    }
}