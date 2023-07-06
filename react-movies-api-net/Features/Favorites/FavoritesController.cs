using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_movies_api_net.Features.Favorites.Commands.AddFavorite;
using react_movies_api_net.Features.Favorites.Commands.RemoveFavorite;
using react_movies_api_net.Features.Favorites.Queries.GetFavorites;
using react_movies_api_net.Services.CurrentUser;

namespace react_movies_api_net.Features.Favorites
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<GetFavoritesQueryResponse>> GetFavorites([FromServices] ICurrentUserService currentUser)
        {
            return _mediator.Send(new GetFavoritesQuery(currentUser.User.Id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddFavorite([FromRoute] int id, [FromServices] ICurrentUserService currentUser)
        {
            await _mediator.Send(new AddFavoriteCommand(id, currentUser.User.Id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFavorite([FromRoute] int id, [FromServices] ICurrentUserService currentUser)
        {
            await _mediator.Send(new RemoveFavoriteCommand(id, currentUser.User.Id));
            return NoContent();
        }

    }
}
