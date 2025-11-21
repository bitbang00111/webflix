using System.Diagnostics;
using DevOpsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using DevOpsDemo.Data;
using DevOpsDemo.Data.Models;
using DevOpsDemo.Controllers.ViewModels;

namespace DevOpsDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevOpsDemoContext _context;

        // El contexto viene inyectado por el runtime
        public HomeController(DevOpsDemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<MovieViewModel> movies;
            var x = _context.Movies.ToList();
            movies = (from m in _context.Movies
                          select new MovieViewModel
                          {
                              ID = m.ID,
                              Name = m.Name,
                              Description = m.Description,
                              ImgUrl = m.ImgUrl,
                              TrailerUrl = m.TrailerUrl,
                              Year = m.Year,
                              DirectorName = m.Director.FirstName + " " + m.Director.LastName,
                              Rating = m.Rating.Count() > 0 ? (m.Rating.Sum(x => x.Star) / m.Rating.Count()) / 2 : 0,
                              Actors = m.Actor.Select(x => new ActorViewModel { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName }).ToList()
                          }).ToList();
            

            #region Unit test: Division by zero
            //int i = 0;
            //int j = 10 / i;
            #endregion

            return View(movies);
        }

        public IActionResult About()
        {
            ViewBag.Message = "Webflix - Movie streaming app";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Página de contacto";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
