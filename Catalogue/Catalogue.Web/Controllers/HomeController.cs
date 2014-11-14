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
        public ActionResult Index()
        {
            ILog logger = LogManager.GetLogger(typeof(HomeController));

            try
            {
                throw new InvalidOperationException();
            }
            catch (Exception ex)
            {
                logger.Error("An error happened!", ex);
            }

            return View();
        }
    }
}