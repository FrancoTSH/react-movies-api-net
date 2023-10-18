using MediatR;
using Microsoft.EntityFrameworkCore;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;
using react_movies_api_net.Features.Auth.ResponseModels;
using react_movies_api_net.Services.Security;

namespace react_movies_api_net.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
    {
        private readonly DBContext _context;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(DBContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email, cancellationToken: cancellationToken);


            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
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
