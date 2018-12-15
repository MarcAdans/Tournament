using AutoMapper;
using MediatR;
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

        public QueryTournamentHandler(IMapper mapper,
            ILambda3MovieConnectorApi lambda3Api,
            IImdbMovieConnectorApi imdbApi)
        {
            this.mapper = mapper;

            this.lambda3Api = lambda3Api;
            this.imdbApi = imdbApi;
        }

        public async Task<Response> Handle(QueryTournamentRequest request, CancellationToken cancellationToken)
        {
            var lambda3Movies = await lambda3Api.GetMoviesAsync();
            var except = request.Movies.Except(lambda3Movies.Select(s => s.Id));

            if (except.Any())
            {
                request.AddNotification("Movies", "Não foram encontrados todos os filmes correspondentes em nossa base de dados");
                return new Response(request.Notifications, true);
            }

            var movies = mapper.Map<IEnumerable<Movie>>(lambda3Movies)
                                       .OrderBy(m => m.Title)
                                       .Select(m => m);
            await imdbApi.UpdateMoviesAsync(movies);

            var result = new CompleteTournament
            {
                Movies = movies
            };

            while (movies.Count() > 1)
            {
                var match = CreateMatchups(movies);
                result.AddMatches(match);
                movies = PlayRound(match);
            }

            return new Response(result);
        }
    }
}