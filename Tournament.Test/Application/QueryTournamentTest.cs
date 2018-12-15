using AutoMapper;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
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
    public class QueryTournamentTest
    {
        private const string MovieName = "The Incredibles";
        private const string MovieId = "tt0317705";

        private const string ChampionId = "tt4154756";
        private const string ViceChampionId = "tt3606756";

        private readonly IImdbMovieConnectorApi imdbApi;
        private readonly ILambda3MovieConnectorApi lambda3Api;

        private readonly IMapper mapper;
        private readonly QueryTournamentHandler handler;
        private readonly ILogger<QueryTournamentHandler> logger;

        public QueryTournamentTest()
        {
            mapper = MapperHelper.GetMapper();
            logger = LoggerHelper.GetLogger<QueryTournamentHandler>();

            imdbApi = Substitute.For<IImdbMovieConnectorApi>();
            lambda3Api = Substitute.For<ILambda3MovieConnectorApi>();

            handler = new
                QueryTournamentHandler(mapper, logger, lambda3Api, imdbApi);
        }

        [Fact]
        public async Task Should_OkPostAsync()
        {
            lambda3Api.GetMoviesAsync()
                       .Returns(CreateListMovies());

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

            var response = await handler.Handle(
                new QueryTournamentRequest(CreateListPostMovies()),
                    CancellationToken.None)
                    .ConfigureAwait(false);

            Assert.Equal(1, counter);
            Assert.NotNull(response);
            Assert.IsType<CompleteTournament>(response.Data);
            var result = (CompleteTournament)response.Data;

            Assert.Equal(result.Champion, ChampionId);
            Assert.Equal(result.ViceChampion, ViceChampionId);
        }

        [Fact]
        public void Should_FailModelRequestDuplicated()
        {
            var request = new QueryTournamentRequest(
                new List<String>
                {
                    "tt3606756",
                    "tt4881806",
                    "tt5164214",
                    "tt7784604",
                    "tt7784604",
                    "tt7784604",
                });

            Assert.True(request.Invalid);
        }

        [Fact]
        public void Should_FailModelRequestInvalidItem()
        {
            var request = new QueryTournamentRequest(
                new List<String>
                {
                    "3606756",
                    "4881806",
                    "5164214",
                    "7784604",
                    "7784604",
                    "7784604",
                });

            Assert.True(request.Invalid);
        }

        [Fact]
        public void Should_FailModelRequestOneItem()
        {
            var request = new QueryTournamentRequest(
                new List<String>
                {
                    "tt3606756"
                });

            Assert.True(request.Invalid);
        }

        [Fact]
        public void Should_FailModelRequestInvalidMatches()
        {
            var request = new QueryTournamentRequest(
                new List<String>
                {
                    "tt3606756",
                    "tt4881806",
                    "tt5164214",
                });

            Assert.True(request.Invalid);
        }

        private static IEnumerable<string> CreateListPostMovies()
        {
            return new List<String>
            {
                "tt3606756",
                "tt4881806",
                "tt5164214",
                "tt7784604",
                "tt4154756",
                "tt5463162",
                "tt3778644",
                "tt3501632"
            };
        }

        private static List<Lambda3Movie> CreateListMovies()
        {
            return new List<Lambda3Movie>
                       {
                        new Lambda3Movie
                        {
                            Id =  "tt3606756",
                            Title =  "Os Incríveis 2",
                            Year =  2018,
                            Rate =  8.5M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt4881806",
                            Title =  "Jurassic World: Reino Ameaçado",
                            Year =  2018,
                            Rate =  6.7M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt5164214",
                            Title =  "Oito Mulheres e um Segredo",
                            Year =  2018,
                            Rate =  6.3M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt7784604",
                            Title =  "Hereditário",
                            Year =  2018,
                            Rate =  7.8M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt4154756",
                            Title =  "Vingadores: Guerra Infinita",
                            Year =  2018,
                            Rate =  8.8M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt5463162",
                            Title =  "Deadpool 2",
                            Year =  2018,
                            Rate =  8.1M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt3778644",
                            Title =  "Han Solo: Uma História Star Wars",
                            Year =  2018,
                            Rate =  7.2M
                        },
                        new Lambda3Movie
                        {
                            Id =  "tt3501632",
                            Title =  "Thor: Ragnarok",
                            Year =  2017,
                            Rate =  7.9M
                        },
                       };
        }
    }
}