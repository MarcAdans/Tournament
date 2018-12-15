namespace Tournament.Domain.MovieContext.Models
{
    public class Movie
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public int Year { get; set; }

        public decimal Rate { get; set; }

        public Movie GetWinner(Movie t2)
        {
            return ((Rate == t2.Rate && Title.CompareTo(t2.Title) > 0) ||
                     Rate > t2.Rate
                   )
                 ? this
                 : t2;
        }

        public Movie GetLoser(Movie t2)
        {
            return ((Rate == t2.Rate && Title.CompareTo(t2.Title) < 0) ||
                     Rate < t2.Rate
                   )
                 ? this
                 : t2;
        }
    }
}