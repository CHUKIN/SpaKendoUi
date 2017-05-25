using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Лаба2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Api",
                url: "Api/{action}",
                defaults: new { controller = "Api", action = "Index" }
            );

            routes.MapRoute(
                name: "Spa",
                url: "{*.}",
                defaults: new { controller = "Spa", action = "Index" }
            );
        }
    }
}
