using MediatR;

namespace react_movies_api_net.Features.Auth.Commands.Logout
{
    public record LogoutCommand(int UserId) : IRequest;
}
