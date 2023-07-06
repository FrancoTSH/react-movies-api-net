using Microsoft.EntityFrameworkCore;
using react_movies_api_net.Data.Entities;

namespace react_movies_api_net.Data
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("movies_type_enum", new[] { "movie", "series" });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.HasIndex(e => e.Slug, "UQ_6ed86498aefe0e545548ca31b78")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BackdropImg)
                    .HasColumnType("character varying")
                    .HasColumnName("backdrop_img");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Genre)
                    .HasColumnType("character varying")
                    .HasColumnName("genre");

                entity.Property(e => e.PosterImg)
                    .HasColumnType("character varying")
                    .HasColumnName("poster_img");

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Slug)
                    .HasColumnType("character varying")
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ_97672ac88f789774dd47f7c8be3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.PhotoUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("photo_url");

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(128)
                    .HasColumnName("refresh_token");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "FavoriteMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_ddd24770a764104e90585002fb1"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_7f693a9735c5e9c844e48af0861"),
                        j =>
                        {
                            j.HasKey("UserId", "MovieId").HasName("PK_9ed10960200dc885de39039615e");

                            j.ToTable("favorite_movies");

                            j.HasIndex(new[] { "UserId" }, "IDX_7f693a9735c5e9c844e48af086");

                            j.HasIndex(new[] { "MovieId" }, "IDX_ddd24770a764104e90585002fb");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
