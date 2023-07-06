namespace react_movies_api_net.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Password { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string? RefreshToken { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
