//using DevOpsDemo.Data.Models;
//using System.Data.Entity.Migrations;
//using System.IO;

//namespace DevOpsDemo.Data.Migrations
//{
//    internal sealed class Configuration : DbMigrationsConfiguration<DevOpsDemo.Data.DevOpsDemoContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false; // mejor control manual
//        }

//        protected override void Seed(DevOpsDemo.Data.DevOpsDemoContext context)
//        {
//            // Ejemplo de datos iniciales
//            context.Directors.AddOrUpdate(
//                d => d.LastName,
//                new Director { FirstName = "Steven", LastName = "Spielberg" },
//                new Director { FirstName = "Christopher", LastName = "Nolan" }
//            );

//            context.SaveChanges();

//            var nolan = context.Directors.SingleOrDefault(d => d.LastName == "Nolan");

//            context.Movies.AddOrUpdate(
//                m => m.Name,
//                new Movie
//                {
//                    Name = "Inception",
//                    Description = "A mind-bending thriller",
//                    Year = 2010,
//                    Director = nolan
//                }
//            );

//            // … añade actores, ratings, etc. si quieres
//        }
//    }
//}
