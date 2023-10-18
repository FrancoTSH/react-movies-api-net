using MediatR;
using Microsoft.EntityFrameworkCore;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;
using react_movies_api_net.Features.Auth.ResponseModels;
using react_movies_api_net.Services.Security;

namespace react_movies_api_net.Features.Auth.Commands.GetRefreshToken
{
    public class GetRefreshTokenCommandHandler : IRequestHandler<GetRefreshTokenCommand, AuthenticationResponse>
    {
        private readonly IJwtService _jwtService;
        private readonly DBContext _context;

        public GetRefreshTokenCommandHandler(IJwtService jwtService, DBContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<AuthenticationResponse> Handle(GetRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshTokenDecoded = _jwtService.Decode(request.RefreshToken);
            var refreshTokenSubject = _jwtService.GetSubject(refreshTokenDecoded);

            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.ToString() == refreshTokenSubject, cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new UnauthorizedException();
            }

            var isRefreshTokenMatching = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshToken);
            var isTokenValid = _jwtService.ValidateToken(request.RefreshToken);

            if (!isTokenValid || !isRefreshTokenMatching)
            {
                throw new UnauthorizedException();
            }

            var accessToken = _jwtService.GenerateToken(user.Id.ToString());
            var refreshToken = _jwtService.GenerateToken(user.Id.ToString());

            return new AuthenticationResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
