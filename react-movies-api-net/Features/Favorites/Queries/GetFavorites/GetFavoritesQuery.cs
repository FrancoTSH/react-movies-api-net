using MediatR;

namespace react_movies_api_net.Features.Favorites.Queries.GetFavorites
{
    public record GetFavoritesQuery(int UserId) : IRequest<List<GetFavoritesQueryResponse>>;
}
