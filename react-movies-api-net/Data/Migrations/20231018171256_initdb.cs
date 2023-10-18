using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace react_movies_api_net.Data.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:movies_type_enum", "movie,series");

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    runtime = table.Column<int>(type: "integer", nullable: false),
                    slug = table.Column<string>(type: "character varying", nullable: false),
                    genre = table.Column<string>(type: "character varying", nullable: false),
                    type = table.Column<string>(type: "character varying", nullable: false),
                    backdrop_img = table.Column<string>(type: "character varying", nullable: false),
                    poster_img = table.Column<string>(type: "character varying", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    photo_url = table.Column<string>(type: "character varying", nullable: true),
                    refresh_token = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "favorite_movies",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    movie_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_9ed10960200dc885de39039615e", x => new { x.user_id, x.movie_id });
                    table.ForeignKey(
                        name: "FK_7f693a9735c5e9c844e48af0861",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ddd24770a764104e90585002fb1",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_7f693a9735c5e9c844e48af086",
                table: "favorite_movies",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IDX_ddd24770a764104e90585002fb",
                table: "favorite_movies",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "UQ_6ed86498aefe0e545548ca31b78",
                table: "movies",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_97672ac88f789774dd47f7c8be3",
                table: "users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorite_movies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
