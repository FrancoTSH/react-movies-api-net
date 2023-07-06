using AutoMapper;
using react_movies_api_net.Data.Entities;

namespace react_movies_api_net.Features.Movies.Queries.GetMovie
{
    public class GetMovieQueryProfile : Profile
    {
        public GetMovieQueryProfile() => CreateMap<Movie, GetMovieQueryResponse>();
    }
}
