﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using react_movies_api_net.Data;

#nullable disable

namespace react_movies_api_net.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231018171256_initdb")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "movies_type_enum", new[] { "movie", "series" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FavoriteMovie", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    b.HasKey("UserId", "MovieId")
                        .HasName("PK_9ed10960200dc885de39039615e");

                    b.HasIndex(new[] { "UserId" }, "IDX_7f693a9735c5e9c844e48af086");

                    b.HasIndex(new[] { "MovieId" }, "IDX_ddd24770a764104e90585002fb");

                    b.ToTable("favorite_movies", (string)null);
                });

            modelBuilder.Entity("react_movies_api_net.Data.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropImg")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("backdrop_img");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("genre");

                    b.Property<string>("PosterImg")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("poster_img");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<int>("Runtime")
                        .HasColumnType("integer")
                        .HasColumnName("runtime");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("slug");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "UQ_6ed86498aefe0e545548ca31b78")
                        .IsUnique();

                    b.ToTable("movies", (string)null);
                });

            modelBuilder.Entity("react_movies_api_net.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("password");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("character varying")
                        .HasColumnName("photo_url");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("refresh_token");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("status")
                        .HasDefaultValueSql("true");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UQ_97672ac88f789774dd47f7c8be3")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("FavoriteMovie", b =>
                {
                    b.HasOne("react_movies_api_net.Data.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ddd24770a764104e90585002fb1");

                    b.HasOne("react_movies_api_net.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_7f693a9735c5e9c844e48af0861");
                });
#pragma warning restore 612, 618
        }
    }
}
