using AutoMapper;
using react_movies_api_net.Data.Entities;

namespace react_movies_api_net.Features.Favorites.Queries.GetFavorites
{
    public class GetFavoritesQueryProfile : Profile
    {
        public GetFavoritesQueryProfile() =>
        CreateMap<Movie, GetFavoritesQueryResponse>();
    }
}
