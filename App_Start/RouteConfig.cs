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
                url: "Api/{action}/{id}",
                defaults: new { controller = "Api", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Spa",
                url: "{*.}",
                defaults: new { controller = "Spa", action = "Index" }
            );
        }
    }
}
