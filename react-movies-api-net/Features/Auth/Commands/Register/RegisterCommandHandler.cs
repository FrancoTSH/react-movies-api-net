using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Data.Entities;
using react_movies_api_net.Features.Auth.ResponseModels;
using react_movies_api_net.Services.Security;

namespace react_movies_api_net.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
    {
        private readonly DBContext _context;
        private readonly IJwtService _jwtService;
        public RegisterCommandHandler(DBContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        public async Task<AuthenticationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword,
            };

            _context.Add(user);

            await _context.SaveChangesAsync();

            var accessToken = _jwtService.GenerateToken(user.Id.ToString());
            var refreshToken = _jwtService.GenerateToken(user.Id.ToString());

            string hashedRefreshToken = BCrypt.Net.BCrypt.HashPassword(refreshToken);

            user.RefreshToken = hashedRefreshToken;

            await _context.SaveChangesAsync();

            return new AuthenticationResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
