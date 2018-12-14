using AutoMapper;
using MediatR;
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

        public QueryMoviesHandler(IMapper mapper,
            ILambda3MovieConnectorApi lambda3Api,
            IImdbMovieConnectorApi imdbApi)
        {
            this.mapper = mapper;

            this.lambda3Api = lambda3Api;
            this.imdbApi = imdbApi;
        }

        public async Task<IEnumerable<Movie>> Handle(QueryMoviesRequest request, CancellationToken cancellationToken)
        {
            var lambda3Movies = await lambda3Api.GetMoviesAsync();
            var movies = mapper.Map<IEnumerable<Movie>>(lambda3Movies);
            await imdbApi.UpdateMoviesAsync(movies);
            return movies;
        }
    }
}