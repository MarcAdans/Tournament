using Newtonsoft.Json;

namespace Tournament.Domain.MovieContext.Models
{
    public class Movie
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public int Year { get; set; }

        public decimal Rate { get; set; }
    }
}