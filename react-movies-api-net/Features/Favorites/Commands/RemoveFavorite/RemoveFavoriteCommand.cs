using MediatR;

namespace react_movies_api_net.Features.Favorites.Commands.RemoveFavorite
{
    public record RemoveFavoriteCommand(int MovieId, int UserId) : IRequest;
}
