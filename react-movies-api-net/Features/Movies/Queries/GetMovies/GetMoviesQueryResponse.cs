namespace react_movies_api_net.Features.Movies.Queries.GetMovies
{
    public class GetMoviesQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string PosterImg { get; set; } = default!;
    }
}
