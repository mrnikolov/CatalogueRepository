[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace Catalogue.Web
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    using System;
    using Catalogue.Models.Entities;
    using Catalogue.Models;

    public partial class Startup
    {
        public static Func<UserManager<Users>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app) {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("auth/login")
            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<Users>
                    (new UserStore<Users>(new ApplicationDbContext()));

                return usermanager;
            };
        }
    }
}