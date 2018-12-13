using MediatR;
using System.Collections.Generic;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Application.ReadContext.TeamContext.Requests
{
    public class QueryMoviesRequest : IRequest<IEnumerable<Movie>>
    {
    }
}