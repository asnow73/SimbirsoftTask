using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimbirsoftTask.Models.Repository;

namespace SimbirsoftTask.Controllers
{
    public class HomeController : Controller
    {
        private SqlRepository repo = new SqlRepository();

        public ActionResult Index()
        {
            //var roles = repo.Roles.ToList();
            //return View(roles);
            return View();
        }

    }
}