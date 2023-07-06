using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_movies_api_net.Features.Users.Commands.UpdateProfile;
using react_movies_api_net.Services.CurrentUser;

namespace react_movies_api_net.Features.Users
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile([FromServices] ICurrentUserService currentUser)
        {
            var response = await _mediator.Send(currentUser.User.Id);

            return Ok(response);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileCommand command, [FromServices] ICurrentUserService currentUser)
        {
            command.Id = currentUser.User.Id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
