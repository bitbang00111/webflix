using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOpsDemo.Data;
using DevOpsDemo.Web.ViewModels;

namespace DevOpsDemo.Web.Controllers
{
    public class DirectorController : Controller
    {
        public ActionResult Index()
        {
            List<DirectorViewModel> director;
            using (var context = new DemoContext())
            {
                director = (from m in context.Director
                         select new DirectorViewModel
                         {
                             ID = m.ID,
                             FirstName = m.FirstName,
                             LastName = m.LastName,
                             Birthdate = m.Birthdate
                         }).ToList();
            }

            return View(director);
        }
    }
}