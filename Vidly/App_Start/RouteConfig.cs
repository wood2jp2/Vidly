using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* routes.MapMvcAttributeRoutes(); */ // initializes attr routing

            routes.MapRoute( // three parameters
                "MoviesByReleaseDate", // unique name for route
                "movies/released/{year}/{month}", // route endpoint with any outline-able params
                new { controller = "Movies", action = "ByReleaseDate" }, // anon object, specify Controller to handle and Action within that controller
                new { year = @"2015||2016", month = @"\d{2}"} // anon object to outline constraints (currently regex)
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
