using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using PaGolok.Web.App_Start;
using System.Web.Optimization;
using System.Data.Entity;
using PaGolok.Data;
using PaGolok.Data.Migrations;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;


namespace PaGolok.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }
    }
}
