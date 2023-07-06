using MediatR;
using react_movies_api_net.Features.Movies.Queries.GetMovie;

namespace react_movies_api_net.Features.Movies.Queries.GetRandomMovie
{
    public record GetRandomMovieQuery() : IRequest<GetMovieQueryResponse>;
}
