using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;

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
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] QueryTournamentRequest request)
        {
            var movies = await mediator.Send(request).ConfigureAwait(false);

            if (movies.HasError)
            {
                return BadRequest(movies.Data);
            }

            return Ok(movies.Data);
        }
    }
}