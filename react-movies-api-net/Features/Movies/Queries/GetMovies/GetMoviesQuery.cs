using MediatR;

namespace react_movies_api_net.Features.Movies.Queries.GetMovies
{
    public record GetMoviesQuery(string Title, string Genre, string OrderBy, string SortBy) : IRequest<List<GetMoviesQueryResponse>>;
}
