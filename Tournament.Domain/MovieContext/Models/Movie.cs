using Newtonsoft.Json;

namespace Tournament.Domain.MovieContext.Models
{
    public class Movie
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