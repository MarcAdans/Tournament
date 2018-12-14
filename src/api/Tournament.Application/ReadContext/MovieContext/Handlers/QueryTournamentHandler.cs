using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.Models;

namespace Tournament.Application.ReadContext.MovieContext.Handlers
{
    public class QueryTournamentHandler : IRequestHandler<QueryTournamentRequest, Response>
    {
        public QueryTournamentHandler()
        {
        }

        public async Task<Response> Handle(QueryTournamentRequest request, CancellationToken cancellationToken)
        {            
            return new Response("oi");
        }
    }
}