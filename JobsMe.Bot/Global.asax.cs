using JobsMe.BotApp.Models;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobsMe.BotApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Trace.TraceError("Appliation start...");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            JobsMe.BotApp.Models.Bot.Get();
        }
    }
}
