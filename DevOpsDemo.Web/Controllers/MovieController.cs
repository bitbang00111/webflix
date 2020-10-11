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
    public class MovieController : Controller
    {
        public ActionResult Index()
        {
            List<ActorViewModel> actor;
            using (var context = new DemoContext())
            {
                actor = (from m in context.Actor
                          select new ActorViewModel
                          {
                              ID = m.ID,
                              FirstName = m.FirstName,
                              LastName = m.LastName,
                              Birthdate = m.Birthdate
                          }).ToList();
            }

            return View(actor);
        }
    }
}