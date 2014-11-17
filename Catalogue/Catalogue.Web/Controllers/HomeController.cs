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
        ILog logger;
        public HomeController()
        {
            this.logger = LogManager.GetLogger(typeof(HomeController));
        }
        public ActionResult Index()
        {
           

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