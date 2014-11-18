using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILog logger;

        public HomeController(ILog logger)
        {
            this.logger = logger;
        }

        public ActionResult Index()
        {
            //throw new InvalidOperationException();
            //try
            //{
            //    throw new InvalidOperationException();
            //}
            //catch (Exception ex)
            //{
            //    logger.Error("An error happened!", ex);
            //}

            return View();
        }
    }
}