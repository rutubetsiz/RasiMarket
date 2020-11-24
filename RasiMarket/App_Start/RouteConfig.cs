using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RasiMarket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "{categoryUrl}-c-{id}",
                defaults: new { controller = "Category", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "GetProductDetail",
               url: "urun-p-{id}",
               defaults: new { controller = "Home", action = "GetProductDetail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "About",
               url: "hakkimizda",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Contact",
               url: "iletisim",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
