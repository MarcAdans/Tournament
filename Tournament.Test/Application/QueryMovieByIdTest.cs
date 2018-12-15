using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.Contracts;
using Tournament.Domain.ImdbContext.Models;
using Xunit;
using static Tournament.Test.Domain.Services.ModelService;

namespace Tournament.Test.Application
{
    public class QueryMovieByIdTest
    {
        private const string MovieName = "The Incredibles";
        private const string MovieId = "tt0317705";

        private readonly IImdbMovieConnectorApi connectorApi;
        private readonly QueryMovieByIdHandler handler;
        private readonly ILogger<QueryMovieByIdHandler> logger;

        public QueryMovieByIdTest()
        {
            connectorApi = Substitute.For<IImdbMovieConnectorApi>();
            logger = LoggerHelper.GetLogger<QueryMovieByIdHandler>();

            handler = new QueryMovieByIdHandler(connectorApi, logger);
        }

        [Fact]
        public async Task Should_OkGetMovieByIdAsync()
        {
            connectorApi.GetMovieAsync(Arg.Any<string>())
                       .Returns(new ImdbMovie
                       {
                           Title = MovieName,
                           Year = "2004",
                           Poster = "https://m.media-amazon.com/images/M/MV5BMTY5OTU0OTc2NV5BMl5BanBnXkFtZTcwMzU4MDcyMQ@@._V1_SX300.jpg",
                           Rating = "8.0",
                           Id = MovieId
                       });

            var response = await handler.Handle(new QueryMovieByIdRequest("tt0317705")
                                    , CancellationToken.None);

            Assert.NotNull(response);
            Assert.Equal(response.Title, MovieName);
            Assert.Equal(response.Id, MovieId);
        }

        [Fact]
        public async Task Should_FailGetMovieByIdAsync()
        {
            connectorApi.GetMovieAsync(Arg.Any<string>())
                       .Returns(default(ImdbMovie));

            var response = await handler.Handle(new QueryMovieByIdRequest("tt0317705")
                                    , CancellationToken.None);

            Assert.Null(response);
        }

        [Fact]
        public void Should_FailModelRequest()
        {
            var request = new QueryMovieByIdRequest("0317705");

            Assert.True(ValidateModel(request).Any());
        }
    }
}