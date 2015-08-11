using System.Web.Mvc;
using System.Web.Routing;

namespace VitalFew.Transdev.Australasia.Data.Api.Console
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "ClientObjects",
              url: "ClientObjects/{id}",
              defaults: new { controller = "ClientObjects", action = "Index", id = UrlParameter.Optional, }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional, }
            );
            
        }
    }
}
