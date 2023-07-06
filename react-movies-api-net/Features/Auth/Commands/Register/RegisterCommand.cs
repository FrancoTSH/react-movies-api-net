using MediatR;
using react_movies_api_net.Features.Auth.ResponseModels;

namespace react_movies_api_net.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<AuthenticationResponse>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
