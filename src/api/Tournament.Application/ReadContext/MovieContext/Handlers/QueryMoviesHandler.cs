using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.Contracts;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Handlers
{
    public class QueryMoviesHandler : IRequestHandler<QueryMoviesRequest, IEnumerable<Movie>>
    {
        private readonly ILambda3MovieConnectorApi lambda3Api;
        private readonly IImdbMovieConnectorApi imdbApi;
        private readonly IMapper mapper;
        private readonly ILogger<QueryMoviesHandler> logger;

        public QueryMoviesHandler(IMapper mapper,
            ILogger<QueryMoviesHandler> logger,
            ILambda3MovieConnectorApi lambda3Api,
            IImdbMovieConnectorApi imdbApi)
        {
            this.mapper = mapper;
            this.logger = logger;

            this.lambda3Api = lambda3Api;
            this.imdbApi = imdbApi;
        }

        public async Task<IEnumerable<Movie>> Handle(QueryMoviesRequest request, CancellationToken cancellationToken)
        {
            logger.LogTrace("Buscando os Filmes na API da Lambda3");
            var lambda3Movies = await lambda3Api.GetMoviesAsync();
            var movies = mapper.Map<IEnumerable<Movie>>(lambda3Movies);

            logger.LogTrace("Atualizando a imagem para poster");
            await imdbApi.UpdateMoviesAsync(movies);
            return movies;
        }
    }
}