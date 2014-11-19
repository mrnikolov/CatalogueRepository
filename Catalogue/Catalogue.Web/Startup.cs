﻿using Microsoft.Owin;
using Owin;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
[assembly: OwinStartupAttribute(typeof(Catalogue.Web.Startup))]
namespace Catalogue.Web
{


    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}