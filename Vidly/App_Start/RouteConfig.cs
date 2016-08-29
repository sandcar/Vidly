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


            routes.MapMvcAttributeRoutes();



            // Esta é a forma simples de criar routes custom. 
            // No entanto em aplicações medias grandes pode ser um problema porque não é flexivel
            // por exemplo se renomear um action num controler terei que vir aqui tratar disso

            //routes.MapRoute(
            //     "MoviesByReleaseDate",
            //     "{controller}/{released}/{year}/{month}",
            //     new
            //     {
            //         controler = "Movies",
            //         Action = "ByReleaseDate"
            //     }
            //     // se quiser restringir ou valodar os parametros na qs
            //     //,
            //     //new
            //     //{ year = @"\d{4}", month = @"\d{2}" }

            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
