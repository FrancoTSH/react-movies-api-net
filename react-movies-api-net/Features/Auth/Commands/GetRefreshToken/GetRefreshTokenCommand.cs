using MediatR;
using react_movies_api_net.Features.Auth.ResponseModels;

namespace react_movies_api_net.Features.Auth.Commands.GetRefreshToken
{
    public class GetRefreshTokenCommand : AuthenticationResponse, IRequest<AuthenticationResponse>
    {
    }
}
