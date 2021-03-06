﻿using System.Web.Mvc;
using System.Web.Routing;

namespace VitalFew.Transdev.Australasia.Data.Api.Console
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Endpoints",
              url: "Endpoints/{id}",
              defaults: new { controller = "Endpoints", action = "Index", id = UrlParameter.Optional, }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional, }
            );
            
        }
    }
}
