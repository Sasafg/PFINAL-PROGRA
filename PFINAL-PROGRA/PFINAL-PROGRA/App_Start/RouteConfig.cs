using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PFINAL_PROGRA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

                routes.MapRoute(
                name: "Iniciar Sesion",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Carrito", action = "Login", id = UrlParameter.Optional }
            );

  
        

        }




    }
}
