using Newtonsoft.Json;

namespace Tournament.Domain.MovieContext.Models
{
    public class Match
    {
        private readonly Movie movie1;
        private readonly Movie movie2;

        public Match(Movie t1, Movie t2)
        {
            movie1 = t1;
            movie2 = t2;
        }

        public string Movide1Id =>
            movie1.Id;

        public string Movide2Id =>
            movie2.Id;

        public string WinnerId =>
            movie1.GetWinner(movie2).Id;

        public string LoserId =>
            movie1.GetLoser(movie2).Id;

        [JsonIgnore]
        public Movie GetWinner =>
                    movie1.GetWinner(movie2);
    }
}