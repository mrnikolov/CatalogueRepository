using log4net;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Catalogue.Web
{
    public class MvcApplication : HttpApplication
    {
        void Application_Error(Object sender, EventArgs e)
        {
            var log = DependencyResolver.Current.GetService<ILog>();
            Exception ex = Server.GetLastError().GetBaseException();

            log.Error("App_Error", ex);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
        }

    }
}
