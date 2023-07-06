using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using react_movies_api_net.Features.Auth.Commands.Login;
using react_movies_api_net.Features.Auth.Commands.Logout;
using react_movies_api_net.Features.Auth.Commands.Register;
using react_movies_api_net.Services.CurrentUser;

namespace react_movies_api_net.Features.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("/logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromServices] ICurrentUserService currentUser)
        {
            await _mediator.Send(new LogoutCommand(currentUser.User.Id));
            return Ok();

        }

        [HttpPost("/refresh-token")]
        [Authorize]
        public async Task<IActionResult> RefreshToken([FromBody] RegisterCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
