using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Api.Feature.Account.App_Start;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace Code
{
    public class Global : HttpApplication
    {
       protected void Application_Start()
        {
            // Code that runs on application startup
            Bootstrapper.Run();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          ///  BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}