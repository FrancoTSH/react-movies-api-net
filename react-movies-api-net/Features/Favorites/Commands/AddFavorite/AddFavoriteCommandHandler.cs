using MediatR;
using react_movies_api_net.Data;
using react_movies_api_net.Exceptions;

namespace react_movies_api_net.Features.Favorites.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand>
    {
        private readonly DBContext _context;
        public AddFavoriteCommandHandler(DBContext context)
        {
            _context = context;
        }
        public async Task Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId, cancellationToken);

            if (movie is null)
            {
                throw new EntityNotFoundException();
            }

            var user = await _context.Users.FindAsync(request.UserId, cancellationToken);

            var isFavorite = user?.Movies.FirstOrDefault(favoriteMovie => favoriteMovie.Id == request.MovieId);

            if (isFavorite == null)
            {
                user?.Movies.Add(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
