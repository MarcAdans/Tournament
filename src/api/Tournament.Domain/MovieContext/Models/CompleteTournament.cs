using System.Collections.Generic;
using System.Linq;

namespace Tournament.Domain.MovieContext.Models
{
    public class CompleteTournament
    {
        private readonly List<IEnumerable<Match>> aggregateMatches;

        public CompleteTournament()
        {
            aggregateMatches = new List<IEnumerable<Match>>();
        }

        public IEnumerable<IEnumerable<Match>> Matches
        {
            get => aggregateMatches;
        }

        public IEnumerable<Movie> Movies { get; set; }

        public string Champion
        {
            get => Matches.Last().Last().WinnerId;
        }

        public string ViceChampion
        {
            get => Matches.Last().Last().LoserId;
        }

        public void AddMatches(IEnumerable<Match> matches) =>
            aggregateMatches.Add(matches);
    }
}