using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevOpsDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Director",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.ActorID, x.MovieID });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, "Samuel L.", "Jackson" },
                    { 2, null, "Anya", "Taylor-Joy" },
                    { 3, null, "Chris", "Pratt" },
                    { 4, null, "Elizabeth", "Banks" },
                    { 5, null, "Chris", "Evans" },
                    { 6, null, "Robert", "Downey JR" },
                    { 7, null, "Leonardo", "Di Caprio" },
                    { 8, null, "Kate", "Winslet" },
                    { 9, null, "Al", "Pacino" },
                    { 10, null, "Michelle", "Pfeiffer" },
                    { 11, null, "Bruce", "Willis" },
                    { 12, null, "John", "Travolta" },
                    { 13, null, "Cristian", "Bale" },
                    { 14, null, "Heath", "Ledger" },
                    { 15, null, "Gary", "Oldman" },
                    { 16, null, "Morgan", "Freeman" },
                    { 17, null, "Paul", "Newman" },
                    { 18, null, "Robert", "Redford" },
                    { 19, null, "Tom", "Hanks" },
                    { 20, null, "Tim", "Allen" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, "M. Night", "Shyamalan" },
                    { 2, null, "Mike", "Mitchell" },
                    { 3, null, "Joss", "Whedan" },
                    { 4, null, "James", "Cameron" },
                    { 5, null, "Brian", "de Palma" },
                    { 6, null, "Quentin", "Tarantino" },
                    { 7, null, "Christopher", "Nolan" },
                    { 8, null, "George", "Roy Hill" },
                    { 9, null, "John", "Lasseter" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "ID", "Description", "DirectorID", "ImgUrl", "Name", "TrailerUrl", "Year" },
                values: new object[,]
                {
                    { 1, "Security guard David Dunn uses his supernatural abilities to track Kevin Wendell Crumb, a disturbed man who has twenty-four personalities.", 1, "https://m.media-amazon.com/images/M/MV5BMTY1OTA2MjI5OV5BMl5BanBnXkFtZTgwNzkxMjU4NjM@._V1_UY209_CR3,0,140,209_AL_.jpg", "Glass (Cristal)", "https://www.imdb.com/list/ls025720609/videoplayer/vi3625105945", 2019 },
                    { 2, "It's been five years since everything was awesome and the citizens are facing a huge new threat: Lego Duplo invaders from outer space, wrecking everything faster than they can rebuild.", 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuTdlUB6pjd1AQAwx5kgLP6EF8egNCu_XoMcB3_mRsHHYF4iUg", "La LEGO película 2", "https://www.youtube.com/watch?v=WPiQJyTwOPY", 2019 },
                    { 3, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", 3, "https://images-na.ssl-images-amazon.com/images/I/71FjI%2B8ewWL._SY445_.jpg", "The Avengers", "https://www.imdb.com/title/tt0848228/videoplayer/vi1891149081", 2012 },
                    { 4, "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", 4, "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg", "Titanic", "https://www.imdb.com/title/tt0120338/videoplayer/vi907189785", 1997 },
                    { 5, "In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.", 5, "https://m.media-amazon.com/images/M/MV5BNjdjNGQ4NDEtNTEwYS00MTgxLTliYzQtYzE2ZDRiZjFhZmNlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg", "Scarface", "https://www.imdb.com/title/tt0086250/videoplayer/vi3939802137", 1983 },
                    { 6, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 6, "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg", "Pulp fiction", "https://www.imdb.com/title/tt0110912/videoplayer/vi2620371481", 1994 },
                    { 7, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 7, "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg", "The Dark Knight", "https://www.imdb.com/title/tt0468569/videoplayer/vi324468761", 2008 },
                    { 8, "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.", 9, "https://m.media-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg", "Toy Story", "https://www.imdb.com/title/tt0114709/videoplayer/vi2052129305", 1995 },
                    { 9, "Two grifters team up to pull off the ultimate con.", 8, "https://m.media-amazon.com/images/M/MV5BNGU3NjQ4YTMtZGJjOS00YTQ3LThmNmItMTI5MDE2ODI3NzY3XkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_UX182_CR0,0,182,268_AL_.jpg", "El Golpe", "https://www.imdb.com/title/tt0070735/videoplayer/vi2717122841", 1973 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieID",
                table: "MovieActor",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MovieID",
                table: "Rating",
                column: "MovieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Director");
        }
    }
}
