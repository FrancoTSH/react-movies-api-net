using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;

namespace react_movies_api_net.Features.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly DBContext _context;

        public LogoutCommandHandler(DBContext context)
        {
            _context = context;
        }
        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);

            if (user is null)
            {
                throw new UnauthorizedException();
            }

            user.RefreshToken = null;

            await _context.SaveChangesAsync();
        }
    }
}
