using MediatR;
using System.Collections.Generic;
using Tournament.Domain.MovieContext.Contracts;

namespace Tournament.Application.ReadContext.TeamContext.Requests
{
    public class QueryMoviesRequest : IRequest<IEnumerable<IMovie>>
    {
    }
}