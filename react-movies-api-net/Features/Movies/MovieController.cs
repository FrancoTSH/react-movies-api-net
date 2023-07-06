using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_movies_api_net.Features.Movies.Queries.GetMovie;
using react_movies_api_net.Features.Movies.Queries.GetMovies;
using react_movies_api_net.Features.Movies.Queries.GetRandomMovie;

namespace react_movies_api_net.Features.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetMovieQuery(id));
            return Ok(response);
        }
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomMovie()
        {
            var response = await _mediator.Send(new GetRandomMovieQuery());
            return Ok(response);
        }
    }
}
