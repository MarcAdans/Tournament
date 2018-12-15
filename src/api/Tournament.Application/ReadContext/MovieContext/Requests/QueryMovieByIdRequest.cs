using MediatR;
using System.ComponentModel.DataAnnotations;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryMovieByIdRequest : IRequest<ImdbMovie>
    {
        public QueryMovieByIdRequest()
        {
        }

        public QueryMovieByIdRequest(string id)
        {
            Id = id;
        }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Movie Id")]
        [RegularExpression(@"(tt)\d+", ErrorMessage = "Invalid Id")]
        public string Id { get; set; }
    }
}