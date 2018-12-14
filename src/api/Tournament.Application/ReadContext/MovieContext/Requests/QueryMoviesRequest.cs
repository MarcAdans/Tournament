using MediatR;
using System.Collections.Generic;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Application.ReadContext.MovieContext.Requests
{
    public class QueryMoviesRequest : IRequest<IEnumerable<Movie>>
    {
    }
}