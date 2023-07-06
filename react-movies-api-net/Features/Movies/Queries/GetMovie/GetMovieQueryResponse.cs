namespace react_movies_api_net.Features.Movies.Queries.GetMovie
{
    public class GetMovieQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; } = default!;
        public int Runtime { get; set; }
        public string BackdropImg { get; set; } = default!;
        public string PosterImg { get; set; } = default!;

    }
}
