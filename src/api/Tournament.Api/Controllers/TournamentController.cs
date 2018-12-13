using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.TeamContext.Requests;
using Tournament.Domain.ImdbContext.Models;
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

        ///// <summary>
        ///// Teste
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}", Name = "Get")]
        //[ProducesResponseType(typeof(ImdbMovie), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        //[ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        //public async Task<IActionResult> GetAsync(string id)
        //{
        //    var movies = await mediator.Send(new QueryMoviesByIdRequest(id)).ConfigureAwait(false);

        //    if (movies is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(movies);
        //}
    }
}