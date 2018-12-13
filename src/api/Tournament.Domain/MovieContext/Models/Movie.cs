using Newtonsoft.Json;
using Tournament.Domain.MovieContext.Contracts;

namespace Tournament.Domain.MovieContext.Models
{
    public class Movie : IMovie
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "ano")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "nota")]
        public decimal Rate { get; set; }
    }
}