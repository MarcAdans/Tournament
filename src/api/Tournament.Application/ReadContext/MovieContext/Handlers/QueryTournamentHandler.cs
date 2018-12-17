using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.Contracts;
using Tournament.Domain.Models;
using Tournament.Domain.MovieContext.Models;
using static Tournament.Domain.Services.TournamentService;

namespace Tournament.Application.ReadContext.MovieContext.Handlers
{
    public class QueryTournamentHandler : IRequestHandler<QueryTournamentRequest, Response>
    {
        private readonly ILambda3MovieConnectorApi lambda3Api;
        private readonly IImdbMovieConnectorApi imdbApi;
        private readonly IMapper mapper;
        private readonly ILogger<QueryTournamentHandler> logger;

        public QueryTournamentHandler(IMapper mapper,
            ILogger<QueryTournamentHandler> logger,
            ILambda3MovieConnectorApi lambda3Api,
            IImdbMovieConnectorApi imdbApi)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.lambda3Api = lambda3Api;
            this.imdbApi = imdbApi;
        }

        public async Task<Response> Handle(QueryTournamentRequest request,
            CancellationToken cancellationToken)
        {
            logger.LogTrace("Buscando os Filmes na API da Lambda3");
            var lambda3Movies = await lambda3Api.GetMoviesAsync()
                                                .ConfigureAwait(false);

            logger.LogTrace("Verifica se todos os filmes foram encontrados");
            lambda3Movies = lambda3Movies.Where(m => request.Movies.Any(r => r == m.Id));
            if (lambda3Movies.Count() != request.Movies.Count())
            {
                logger.LogInformation("Não foram encontrados todos os filmes");

                request.AddNotification("Movies", "Não foram encontrados todos os filmes correspondentes em nossa base de dados");
                return new Response(request.Notifications, true);
            }

            logger.LogTrace("Ordena os filmes para montagem dos desafios");
            var movies = mapper.Map<IEnumerable<Movie>>(lambda3Movies)
                                       .OrderBy(m => m.Title)
                                       .Select(m => m);
            await imdbApi.UpdateMoviesAsync(movies)
                         .ConfigureAwait(false);

            var result = new CompleteTournament
            {
                Movies = movies
            };

            logger.LogTrace("Calculando as partidas");
            while (movies.Count() > 1)
            {
                var match = CreateMatchups(movies);
                result.AddMatches(match);
                movies = Round(match);
            }

            return new Response(result);
        }
    }
}