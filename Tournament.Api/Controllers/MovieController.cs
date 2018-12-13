﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tournament.Application.ReadContext.TeamContext.Requests;
using Tournament.Domain;
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
        /// Seleciona o motorista pelo código
        /// </summary>
        /// <returns>Motorista</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var movies = await mediator.Send(new QueryMoviesRequest()).ConfigureAwait(false);

            if (movies is null)
            {
                return NotFound();
            }

            return Ok(movies);
        }
    }
}