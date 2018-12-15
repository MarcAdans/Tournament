using System.Collections.Generic;
using System.Linq;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Domain.Services
{
    public static class TournamentService
    {
        public static IEnumerable<Match> CreateMatchups(IEnumerable<Movie> movies)
        {
            var matchups = new List<Match>();

            for (int i = 0; i < movies.Count() / 2; i++)
            {
                matchups.Add(new Match(movies.ElementAt(i),
                    movies.ElementAt(movies.Count() - (i + 1))));
            }

            return matchups;
        }

        public static IEnumerable<Movie> Round(IEnumerable<Match> matchups) =>
            matchups.Select(x => x.GetWinner);
    }
}