using AutoMapper;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Handlers;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;
using Tournament.Domain.Lambda3Context.Models;
using Tournament.Domain.MovieContext.Models;
using Xunit;

namespace Tournament.Test.Application
{
    public class QueryMovies
    {
        private const string MovieName = "The Incredibles";
        private const string MovieId = "tt0317705";

        private readonly IImdbMovieConnectorApi imdbApi;
        private readonly ILambda3MovieConnectorApi lambda3Api;

        private readonly IMapper mapper;
        private readonly QueryMoviesHandler handler;

        public QueryMovies()
        {
            mapper = MapperHelper.GetMapper();

            imdbApi = Substitute.For<IImdbMovieConnectorApi>();
            lambda3Api = Substitute.For<ILambda3MovieConnectorApi>();

            handler = new QueryMoviesHandler(mapper, lambda3Api, imdbApi);
        }

        [Fact]
        public async Task Should_OkGetMoviesAsync()
        {
            lambda3Api.GetMoviesAsync()
                       .Returns(new List<Lambda3Movie>
                       {
                           new Lambda3Movie
                           {
                               Title = MovieName,
                               Year = 2004,
                               Rate = 8.0M,
                               Id = MovieId
                           }
                       });

            imdbApi.GetMovieAsync(Arg.Any<string>())
                       .Returns(new ImdbMovie
                       {
                           Title = MovieName,
                           Year = "2004",
                           Poster = "https://m.media-amazon.com/images/M/MV5BMTY5OTU0OTc2NV5BMl5BanBnXkFtZTcwMzU4MDcyMQ@@._V1_SX300.jpg",
                           Rating = "8.0",
                           Id = MovieId
                       });

            var counter = 0;
            imdbApi.When(x => x.UpdateMoviesAsync(Arg.Any<IEnumerable<Movie>>()))
                   .Do(x => counter++);

            var response = await handler.Handle(new QueryMoviesRequest()
                                    , CancellationToken.None);

            Assert.Equal(1, counter);
            Assert.NotNull(response);
            Assert.True(response.Any());
            Assert.Equal(response.First().Title, MovieName);
            Assert.Equal(response.First().Id, MovieId);
        }

        [Fact]
        public async Task Should_FailGetMoviesAsync()
        {
            lambda3Api.GetMoviesAsync()
                       .Returns(default(List<Lambda3Movie>));

            imdbApi.GetMovieAsync(Arg.Any<string>())
                       .Returns(default(ImdbMovie));

            var counter = 0;
            imdbApi.When(x => x.UpdateMoviesAsync(Arg.Any<IEnumerable<Movie>>()))
                   .Do(x => counter++);

            var response = await handler.Handle(new QueryMoviesRequest()
                                    , CancellationToken.None);

            Assert.Equal(1, counter);
            Assert.Null(response);
        }
    }
}