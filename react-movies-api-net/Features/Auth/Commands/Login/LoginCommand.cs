using MediatR;
using react_movies_api_net.Features.Auth.ResponseModels;

namespace react_movies_api_net.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
