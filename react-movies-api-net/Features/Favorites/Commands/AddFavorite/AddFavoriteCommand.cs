using MediatR;

namespace react_movies_api_net.Features.Favorites.Commands.AddFavorite
{
    public record AddFavoriteCommand(int MovieId, int UserId) : IRequest;
}
