using Microsoft.EntityFrameworkCore;
using DevOpsDemo.Data.Models;

namespace DevOpsDemo.Data
{
    public class DevOpsDemoContext : DbContext
    {
        public DevOpsDemoContext(DbContextOptions<DevOpsDemoContext> options)
            : base(options)
        { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Director 1..N Movies
            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movie)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorID)
                .IsRequired(false);

            // Movie 1..N Rating
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Rating)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieID);

            // Many-to-Many Movie–Actor (EF Core genera tabla sola)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actor)
                .WithMany(a => a.Movie)
                .UsingEntity(j => j.ToTable("MovieActor"));


            // Seed de datos
            modelBuilder.Entity<Director>().HasData(
                new Director() { ID = 1, FirstName = "M. Night", LastName = "Shyamalan" },
                new Director() { ID = 2, FirstName = "Mike", LastName = "Mitchell" },
                new Director() { ID = 3, FirstName = "Joss", LastName = "Whedan" },
                new Director() { ID = 4, FirstName = "James", LastName = "Cameron" },
                new Director() { ID = 5, FirstName = "Brian", LastName = "de Palma" },
                new Director() { ID = 6, FirstName = "Quentin", LastName = "Tarantino" },
                new Director() { ID = 7, FirstName = "Christopher", LastName = "Nolan" },
                new Director() { ID = 8, FirstName = "George", LastName = "Roy Hill" },
                new Director() { ID = 9, FirstName = "John", LastName = "Lasseter" }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ID = 1, FirstName = "Samuel L.", LastName = "Jackson" },
                new Actor() { ID = 2, FirstName = "Anya", LastName = "Taylor-Joy" },
                new Actor() { ID = 3, FirstName = "Chris", LastName = "Pratt" },
                new Actor() { ID = 4, FirstName = "Elizabeth", LastName = "Banks" },
                new Actor() { ID = 5, FirstName = "Chris", LastName = "Evans" },
                new Actor() { ID = 6, FirstName = "Robert", LastName = "Downey JR" },
                new Actor() { ID = 7, FirstName = "Leonardo", LastName = "Di Caprio" },
                new Actor() { ID = 8, FirstName = "Kate", LastName = "Winslet" },
                new Actor() { ID = 9, FirstName = "Al", LastName = "Pacino" },
                new Actor() { ID = 10, FirstName = "Michelle", LastName = "Pfeiffer" },
                new Actor() { ID = 11, FirstName = "Bruce", LastName = "Willis" },
                new Actor() { ID = 12, FirstName = "John", LastName = "Travolta" },
                new Actor() { ID = 13, FirstName = "Cristian", LastName = "Bale" },
                new Actor() { ID = 14, FirstName = "Heath", LastName = "Ledger" },
                new Actor() { ID = 15, FirstName = "Gary", LastName = "Oldman" },
                new Actor() { ID = 16, FirstName = "Morgan", LastName = "Freeman" },
                new Actor() { ID = 17, FirstName = "Paul", LastName = "Newman" },
                new Actor() { ID = 18, FirstName = "Robert", LastName = "Redford" },
                new Actor() { ID = 19, FirstName = "Tom", LastName = "Hanks" },
                new Actor() { ID = 20, FirstName = "Tim", LastName = "Allen" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    ID = 1,
                    Name = "Glass (Cristal)",
                    Description = "Security guard David Dunn uses his supernatural abilities to track Kevin Wendell Crumb, a disturbed man who has twenty-four personalities.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTY1OTA2MjI5OV5BMl5BanBnXkFtZTgwNzkxMjU4NjM@._V1_UY209_CR3,0,140,209_AL_.jpg",
                    Year = 2019,
                    TrailerUrl = "https://www.imdb.com/list/ls025720609/videoplayer/vi3625105945",
                    DirectorID = 1,
                },
                new Movie()
                {
                    ID = 2,
                    Name = "La LEGO película 2",
                    Description = "It's been five years since everything was awesome and the citizens are facing a huge new threat: Lego Duplo invaders from outer space, wrecking everything faster than they can rebuild.",
                    ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuTdlUB6pjd1AQAwx5kgLP6EF8egNCu_XoMcB3_mRsHHYF4iUg",
                    Year = 2019,
                    TrailerUrl = "https://www.youtube.com/watch?v=WPiQJyTwOPY",
                    DirectorID = 2
                },
                new Movie()
                {
                    ID = 3,
                    Name = "The Avengers",
                    Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/71FjI%2B8ewWL._SY445_.jpg",
                    Year = 2012,
                    TrailerUrl = "https://www.imdb.com/title/tt0848228/videoplayer/vi1891149081",
                    DirectorID = 3,
                },
                new Movie()
                {
                    ID = 4,
                    Name = "Titanic",
                    Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Year = 1997,
                    TrailerUrl = "https://www.imdb.com/title/tt0120338/videoplayer/vi907189785",
                    DirectorID = 4
                },
                new Movie()
                {
                    ID = 5,
                    Name = "Scarface",
                    Description = "In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BNjdjNGQ4NDEtNTEwYS00MTgxLTliYzQtYzE2ZDRiZjFhZmNlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Year = 1983,
                    TrailerUrl = "https://www.imdb.com/title/tt0086250/videoplayer/vi3939802137",
                    DirectorID = 5
                },
                new Movie()
                {
                    ID = 6,
                    Name = "Pulp fiction",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg",
                    Year = 1994,
                    TrailerUrl = "https://www.imdb.com/title/tt0110912/videoplayer/vi2620371481",
                    DirectorID = 6
                },
                new Movie()
                {
                    ID = 7,
                    Name = "The Dark Knight",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Year = 2008,
                    TrailerUrl = "https://www.imdb.com/title/tt0468569/videoplayer/vi324468761",
                    DirectorID = 7
                },
                new Movie()
                {
                    ID = 8,
                    Name = "Toy Story",
                    Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Year = 1995,
                    TrailerUrl = "https://www.imdb.com/title/tt0114709/videoplayer/vi2052129305",
                    DirectorID = 9
                },
                new Movie()
                {
                    ID = 9,
                    Name = "El Golpe",
                    Description = "Two grifters team up to pull off the ultimate con.",
                    ImgUrl = "https://m.media-amazon.com/images/M/MV5BNGU3NjQ4YTMtZGJjOS00YTQ3LThmNmItMTI5MDE2ODI3NzY3XkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Year = 1973,
                    TrailerUrl = "https://www.imdb.com/title/tt0070735/videoplayer/vi2717122841",
                    DirectorID = 8
                }
            );
        }
    }
}
