using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.CrossCutting;
using Tournament.Domain.Lambda3Context.Models;
using Xunit;

namespace Tournament.Test.CrossCutting
{
    public class CrossCuttingTest
    {
        [Fact]
        public async Task Should_GetHttpClientAsync()
        {
            var result = await HttpClientService
                .GetAsync<List<Lambda3Movie>>("https://copadosfilmes.azurewebsites.net/api/filmes")
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(result.Any());
        }
    }
}