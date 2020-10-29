using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Cast = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "Description", "Director", "Genre", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "", "", "Lee Tamahori", "Action", "Die Another Day", new DateTime(2002, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "", "Tony Scott", "Action", "Top Gun", new DateTime(1986, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", "", "Steven Spielberg", "Action", "Jurassic Park", new DateTime(1993, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", "", "Michael Bay", "Action", "Transformers", new DateTime(2007, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", "", "Roland Emmerich", "Action", "Independence Day", new DateTime(1996, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
