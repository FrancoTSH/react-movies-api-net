using MediatR;

namespace react_movies_api_net.Features.Movies.Queries.GetMovie
{
    public record GetMovieQuery(int MovieId) : IRequest<GetMovieQueryResponse>;
}
