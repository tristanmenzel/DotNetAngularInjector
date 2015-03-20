using System.Web.Mvc;
using System.Web.Routing;

namespace AngularInjector.Demo
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new Route("{controller}/{action}", new RouteValueDictionary(new{ @controller="Home", @action="Index"}), new MvcRouteHandler()));
        }
    }
}