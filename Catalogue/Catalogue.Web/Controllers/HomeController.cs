using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Controllers
{
    public class HomeController : Controller
    {
        private CatalogueContext db;

        public HomeController(CatalogueContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var usersCount = db.Users.Count();
            return View(usersCount);
        }
    }
}