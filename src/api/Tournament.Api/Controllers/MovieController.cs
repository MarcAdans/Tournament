using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.MovieContext.Requests;
using Tournament.Domain.ImdbContext.Models;
using Tournament.Domain.MovieContext.Models;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator"></param>
        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Exibe a lista de Filmes
        /// </summary>
        /// <returns>Lista de Filmes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var movies = await mediator.Send(new QueryMoviesRequest())
                                       .ConfigureAwait(false);

            return movies is null
                ? NotFound()
                : (IActionResult)Ok(movies);
        }

        /// <summary>
        /// Busca informações detalhadas de um filme
        /// </summary>
        /// <param name="id">Código do filme</param>
        /// <returns>Informações do filme da API do IMDB</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ImdbMovie), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync(QueryMovieByIdRequest id)
        {
            var movie = await mediator.Send(id)
                                      .ConfigureAwait(false);

            return movie is null || string.IsNullOrWhiteSpace(movie.Id)
                 ? NotFound()
                 : (IActionResult)Ok(movie);
        }
    }
}