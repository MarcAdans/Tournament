using MediatR;
using System.ComponentModel.DataAnnotations;
using Tournament.Domain.ImdbContext.Models;

namespace Tournament.Application.ReadContext.TeamContext.Requests
{
    public class QueryMoviesByIdRequest : IRequest<ImdbMovie>
    {
        public QueryMoviesByIdRequest()
        {
        }

        public QueryMoviesByIdRequest(string id)
        {
            Id = id;
        }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Movie Id")]
        [RegularExpression(@"(tt)\d+", ErrorMessage ="Invalid Id")]
        public string Id { get; set; }
    }
}