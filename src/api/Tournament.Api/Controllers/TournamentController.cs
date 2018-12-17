using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator"></param>
        public TournamentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Calcula o torneio de desafios dos filmes.
        /// </summary>
        /// <param name="request">Lista de filmes que entraram na disputa</param>
        /// <returns>Cálculo completo sobre os desafios</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CompleteTournament), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Notification), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] QueryTournamentRequest request)
        {
            var movies = await mediator.Send(request)
                                       .ConfigureAwait(false);

            return movies.HasError
                 ? BadRequest(movies.Data)
                 : (IActionResult)Ok(movies.Data);
        }
    }
}