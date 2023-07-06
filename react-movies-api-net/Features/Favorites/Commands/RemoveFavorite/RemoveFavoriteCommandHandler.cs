using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;

namespace react_movies_api_net.Features.Favorites.Commands.RemoveFavorite
{
    public class RemoveFavoriteCommandHandler : IRequestHandler<RemoveFavoriteCommand>
    {
        private readonly DBContext _context;
        public RemoveFavoriteCommandHandler(DBContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveFavoriteCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId, cancellationToken);

            if (movie is null)
            {
                throw new EntityNotFoundException();
            }

            var user = await _context.Users.FindAsync(request.UserId, cancellationToken);

            var favoriteMovie = user?.Movies.FirstOrDefault(favoriteMovie => favoriteMovie.Id == request.MovieId);

            if (favoriteMovie != null)
            {
                user?.Movies.Remove(favoriteMovie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
