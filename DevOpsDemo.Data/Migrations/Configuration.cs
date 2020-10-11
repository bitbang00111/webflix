namespace DevOpsDemo.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DevOpsDemo.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DevOpsDemo.Data.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DevOpsDemo.Data.DemoContext context)
        {
            context.Director.AddOrUpdate(x => x.ID,
                   new Director() { ID = 1, FirstName = "M. Night", LastName = "Shyamalan" },
                   new Director() { ID = 2, FirstName = "Mike", LastName = "Mitchell" },
                   new Director() { ID = 3, FirstName = "Joss", LastName = "Whedan" },
                   new Director() { ID = 4, FirstName = "James", LastName = "Cameron" },
                   new Director() { ID = 5, FirstName = "Brian", LastName = "de Palma" },
                   new Director() { ID = 6, FirstName = "Quentin", LastName = "Tarantino" },
                   new Director() { ID = 7, FirstName = "Christopher", LastName = "Nolan" },
                   new Director() { ID = 8, FirstName = "George", LastName = "Roy Hill" },
            new Director() { ID = 9, FirstName = "John", LastName = "Lasseter" });

            //Actors:
            var samuelLJackson = new Actor() { ID = 1, FirstName = "Samuel L.", LastName = "Jackson" };
            var anyaTaylor = new Actor() { ID = 2, FirstName = "Anya", LastName = "Taylor-Joy" };
            var chrisPratt = new Actor() { ID = 3, FirstName = "Chris", LastName = "Pratt" };
            var elizabethBanks = new Actor() { ID = 4, FirstName = "Elizabeth", LastName = "Banks" };
            var ChrisEvans = new Actor() { ID = 5, FirstName = "Chris", LastName = "Evans" };
            var RobertDowneyJR = new Actor() { ID = 6, FirstName = "Robert", LastName = "Downey JR" };
            var LeonardoDiCaprio = new Actor() { ID = 7, FirstName = "Leonardo", LastName = "Di Caprio" };
            var KateWinslet = new Actor() { ID = 8, FirstName = "Kate", LastName = "Winslet" };
            var AlPacino = new Actor() { ID = 9, FirstName = "Al", LastName = "Pacino" };
            var MichellePfeiffer = new Actor() { ID = 10, FirstName = "Michelle", LastName = "Pfeiffer" };
            var BruceWillis = new Actor() { ID = 11, FirstName = "Bruce", LastName = "Willis" };
            var JohnTravolta = new Actor() { ID = 12, FirstName = "John", LastName = "Travolta" };
            var CristianBale = new Actor() { ID = 13, FirstName = "Cristian", LastName = "Bale" };
            var HeathLedger = new Actor() { ID = 14, FirstName = "Heath", LastName = "Ledger" };
            var GaryOldman = new Actor() { ID = 15, FirstName = "Gary", LastName = "Oldman" };
            var MorganFreeman = new Actor() { ID = 16, FirstName = "Morgan", LastName = "Freeman" };
            var PaulNewman = new Actor() { ID = 17, FirstName = "Paul", LastName = "Newman" };
            var RobertRedford = new Actor() { ID = 18, FirstName = "Robert", LastName = "Redford" };
            var TomHanks = new Actor() { ID = 19, FirstName = "Tom", LastName = "Hanks" };
            var TimAllen = new Actor() { ID = 20, FirstName = "Tim", LastName = "Allen" };


            context.Actor.AddOrUpdate(x => x.ID, samuelLJackson);
            context.Actor.AddOrUpdate(x => x.ID, anyaTaylor);
            context.Actor.AddOrUpdate(x => x.ID, chrisPratt);
            context.Actor.AddOrUpdate(x => x.ID, elizabethBanks);
            context.Actor.AddOrUpdate(x => x.ID, ChrisEvans);
            context.Actor.AddOrUpdate(x => x.ID, RobertDowneyJR);
            context.Actor.AddOrUpdate(x => x.ID, LeonardoDiCaprio);
            context.Actor.AddOrUpdate(x => x.ID, KateWinslet);
            context.Actor.AddOrUpdate(x => x.ID, AlPacino);
            context.Actor.AddOrUpdate(x => x.ID, MichellePfeiffer);
            context.Actor.AddOrUpdate(x => x.ID, BruceWillis);
            context.Actor.AddOrUpdate(x => x.ID, JohnTravolta);
            context.Actor.AddOrUpdate(x => x.ID, CristianBale);
            context.Actor.AddOrUpdate(x => x.ID, HeathLedger);
            context.Actor.AddOrUpdate(x => x.ID, GaryOldman);
            context.Actor.AddOrUpdate(x => x.ID, MorganFreeman);
            context.Actor.AddOrUpdate(x => x.ID, PaulNewman);
            context.Actor.AddOrUpdate(x => x.ID, RobertRedford);
            context.Actor.AddOrUpdate(x => x.ID, TomHanks);
            context.Actor.AddOrUpdate(x => x.ID, TimAllen);
            context.SaveChanges();

            var glass = new Movie()
            {
                ID = 1,
                Name = " Glass (Cristal)",
                Description = "Security guard David Dunn uses his supernatural abilities to track Kevin Wendell Crumb, a disturbed man who has twenty-four personalities.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTY1OTA2MjI5OV5BMl5BanBnXkFtZTgwNzkxMjU4NjM@._V1_UY209_CR3,0,140,209_AL_.jpg",
                Year = 2019,
                TrailerUrl = "https://www.imdb.com/list/ls025720609/videoplayer/vi3625105945",
                DirectorID = 1,
            };
            glass.Actor.Add(samuelLJackson);
            glass.Actor.Add(anyaTaylor);

            var lego = new Movie()
            {
                ID = 2,
                Name = "La LEGO película 2",
                Description = "It's been five years since everything was awesome and the citizens are facing a huge new threat: Lego Duplo invaders from outer space, wrecking everything faster than they can rebuild.",
                ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuTdlUB6pjd1AQAwx5kgLP6EF8egNCu_XoMcB3_mRsHHYF4iUg",
                Year = 2019,
                TrailerUrl = "https://www.youtube.com/watch?v=WPiQJyTwOPY",
                DirectorID = 2
            };
            lego.Actor.Add(chrisPratt);
            lego.Actor.Add(elizabethBanks);

            var vengadores = new Movie()
            {
                ID = 3,
                Name = "The Avengers",
                Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/71FjI%2B8ewWL._SY445_.jpg",
                Year = 2012,
                TrailerUrl = "https://www.imdb.com/title/tt0848228/videoplayer/vi1891149081",
                DirectorID = 3,
            };
            vengadores.Actor.Add(samuelLJackson);
            vengadores.Actor.Add(ChrisEvans);
            vengadores.Actor.Add(RobertDowneyJR);

            var titanic = new Movie()
            {
                ID = 4,
                Name = "Titanic",
                Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                Year = 1997,
                TrailerUrl = "https://www.imdb.com/title/tt0120338/videoplayer/vi907189785",
                DirectorID = 4
            };
            titanic.Actor.Add(LeonardoDiCaprio);
            titanic.Actor.Add(KateWinslet);

            var scarface = new Movie()
            {
                ID = 5,
                Name = "Scarface",
                Description = "In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BNjdjNGQ4NDEtNTEwYS00MTgxLTliYzQtYzE2ZDRiZjFhZmNlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg",
                Year = 1983,
                TrailerUrl = "https://www.imdb.com/title/tt0086250/videoplayer/vi3939802137",
                DirectorID = 5
            };
            scarface.Actor.Add(AlPacino);
            scarface.Actor.Add(MichellePfeiffer);

            var pulpfiction = new Movie()
            {
                ID = 6,
                Name = "Pulp fiction",
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg",
                Year = 1994,
                TrailerUrl = "https://www.imdb.com/title/tt0110912/videoplayer/vi2620371481",
                DirectorID = 6
            };
            pulpfiction.Actor.Add(samuelLJackson);
            pulpfiction.Actor.Add(BruceWillis);
            pulpfiction.Actor.Add(JohnTravolta);

            var caballeroOscuro = new Movie()
            {
                ID = 7,
                Name = "The Dark Knight",
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                Year = 2008,
                TrailerUrl = "https://www.imdb.com/title/tt0468569/videoplayer/vi324468761",
                DirectorID = 7
            };
            caballeroOscuro.Actor.Add(CristianBale);
            caballeroOscuro.Actor.Add(HeathLedger);
            caballeroOscuro.Actor.Add(GaryOldman);

            var toyStory = new Movie()
            {
                ID = 8,
                Name = "Toy Story",
                Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg",
                Year = 1995,
                TrailerUrl = "https://www.imdb.com/title/tt0114709/videoplayer/vi2052129305",
                DirectorID = 9
            };
            toyStory.Actor.Add(TomHanks);
            toyStory.Actor.Add(TimAllen);

            var elGolpe = new Movie()
            {
                ID = 9,
                Name = "El Golpe",
                Description = "Two grifters team up to pull off the ultimate con.",
                ImgUrl = "https://m.media-amazon.com/images/M/MV5BNGU3NjQ4YTMtZGJjOS00YTQ3LThmNmItMTI5MDE2ODI3NzY3XkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_UX182_CR0,0,182,268_AL_.jpg",
                Year = 1973,
                TrailerUrl = "https://www.imdb.com/title/tt0070735/videoplayer/vi2717122841",
                DirectorID = 8
            };
            elGolpe.Actor.Add(PaulNewman);
            elGolpe.Actor.Add(RobertRedford);

            context.Movie.AddOrUpdate(x => x.ID, glass);
            context.Movie.AddOrUpdate(x => x.ID, lego);
            context.Movie.AddOrUpdate(x => x.ID, vengadores);
            context.Movie.AddOrUpdate(x => x.ID, titanic);
            context.Movie.AddOrUpdate(x => x.ID, scarface);
            context.Movie.AddOrUpdate(x => x.ID, pulpfiction);
            context.Movie.AddOrUpdate(x => x.ID, caballeroOscuro);
            context.Movie.AddOrUpdate(x => x.ID, toyStory);
            context.Movie.AddOrUpdate(x => x.ID, elGolpe);

            context.Rating.AddOrUpdate(x => x.ID,
                new Rating() { ID = 1, Star = 6, ChangeDate = new DateTime(2019, 2, 2), MovieID = 1 },
                new Rating() { ID = 2, Star = 4, ChangeDate = new DateTime(2019, 2, 1), MovieID = 1 },
                new Rating() { ID = 3, Star = 7, ChangeDate = new DateTime(2019, 2, 2), MovieID = 1 },
                new Rating() { ID = 4, Star = 5, ChangeDate = new DateTime(2019, 2, 1), MovieID = 2 },
                new Rating() { ID = 5, Star = 4, ChangeDate = new DateTime(2019, 3, 2), MovieID = 2 },
                new Rating() { ID = 6, Star = 6, ChangeDate = new DateTime(2019, 6, 1), MovieID = 2 },
                new Rating() { ID = 7, Star = 1, ChangeDate = new DateTime(2019, 7, 2), MovieID = 3 },
                new Rating() { ID = 8, Star = 8, ChangeDate = new DateTime(2019, 2, 1), MovieID = 3 },
                new Rating() { ID = 9, Star = 10, ChangeDate = new DateTime(2019, 3, 2), MovieID = 3 },
                new Rating() { ID = 10, Star = 9, ChangeDate = new DateTime(2019, 5, 1), MovieID = 4 },
                new Rating() { ID = 11, Star = 3, ChangeDate = new DateTime(2019, 11, 2), MovieID = 4 },
                new Rating() { ID = 12, Star = 2, ChangeDate = new DateTime(2019, 9, 1), MovieID = 4 },
                new Rating() { ID = 13, Star = 6, ChangeDate = new DateTime(2019, 8, 2), MovieID = 5 },
                new Rating() { ID = 14, Star = 8, ChangeDate = new DateTime(2019, 3, 1), MovieID = 5 },
                new Rating() { ID = 15, Star = 4, ChangeDate = new DateTime(2019, 5, 2), MovieID = 6 },
                new Rating() { ID = 16, Star = 6, ChangeDate = new DateTime(2019, 2, 1), MovieID = 6 },
                new Rating() { ID = 17, Star = 2, ChangeDate = new DateTime(2019, 1, 2), MovieID = 7 },
                new Rating() { ID = 18, Star = 9, ChangeDate = new DateTime(2019, 12, 1), MovieID = 7 },
                new Rating() { ID = 19, Star = 10, ChangeDate = new DateTime(2019, 10, 2), MovieID = 8 },
                new Rating() { ID = 20, Star = 7, ChangeDate = new DateTime(2019, 9, 1), MovieID = 8 },
                new Rating() { ID = 21, Star = 8, ChangeDate = new DateTime(2019, 6, 2), MovieID = 8 },
                new Rating() { ID = 22, Star = 2, ChangeDate = new DateTime(2019, 7, 1), MovieID = 9 },
                new Rating() { ID = 23, Star = 1, ChangeDate = new DateTime(2019, 5, 2), MovieID = 9 },
                new Rating() { ID = 24, Star = 0, ChangeDate = new DateTime(2019, 2, 1), MovieID = 5 });

            context.SaveChanges();

        }
    }
}
