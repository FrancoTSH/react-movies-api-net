namespace react_movies_api_net.Data.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Slug { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string BackdropImg { get; set; } = null!;
        public string PosterImg { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
