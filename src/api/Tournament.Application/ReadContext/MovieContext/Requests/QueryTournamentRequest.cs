using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tournament.Domain.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryTournamentRequest : EntityBase, IRequest<Response>, INotification
    {
        public const int REQUIRED_QUANTITY_MOVIES = 8;

        public QueryTournamentRequest(IEnumerable<string> movies)
        {
            Movies = movies;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Movies,
                        nameof(Movies),
                        "Informe a lista de filmes")
                .IsTrue(Movies?.Count() > 1,
                        nameof(Movies),
                        "A lista deve ter mais de 1 item")
                .IsTrue(RoundsValid(Movies?.Count()),
                        nameof(Movies),
                        "Não é possível calcular partidas com a quantidade de itens")
                 .IsTrue(Movies?.Distinct().Count() == Movies?.Count(),
                        nameof(Movies),
                        "Existem itens duplicados")
                 .IsTrue(ValidateMoviesItem(),
                        nameof(Movies),
                        "Existem códigos inválidos")
                        );
        }

        public IEnumerable<string> Movies { get; set; }

        private static bool RoundsValid(int? totalMovies) =>
            (totalMovies is null)
            ? false
            : (Math.Pow(2, Math.Round(Math.Log(totalMovies.Value, 2)))
               - totalMovies.Value) == 0;

        private bool ValidateMoviesItem()
        {
            if (Movies is null) return true;

            foreach (var movie in Movies)
            {
                if (!Regex.IsMatch(movie, @"(tt)\d+"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}