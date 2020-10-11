﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOpsDemo.Data;
using DevOpsDemo.Web.ViewModels;

namespace DevOpsDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<MovieViewModel> movies;
            using (var context = new DemoContext())
            {
                movies = (from m in context.Movie
                          select new MovieViewModel
                          {
                              ID = m.ID,
                              Name = m.Name,
                              Description = m.Description,
                              ImgUrl = m.ImgUrl,
                              TrailerUrl = m.TrailerUrl,
                              Year = m.Year,
                              DirectorName = m.Director.FirstName + " " + m.Director.LastName,
                              Rating = m.Rating.Count() > 0 ? (m.Rating.Sum(x => x.Star) / m.Rating.Count())/2 : 0,
                              Actors = m.Actor.Select(x => new ActorViewModel { ID = x.ID, FirstName = x.FirstName, LastName = x.LastName }).ToList()
                          }).ToList();
            }

            #region Unit test: Division by zero
            //int i = 0;
            //int j = 10 / i;
            #endregion

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Webflix - Movie streaming app";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto";

            return View();
        }
    }
}