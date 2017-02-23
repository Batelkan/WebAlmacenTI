using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    null,
            //    "pagina{pagina}/NoItems{NumItems}",
            //    new { Controller = "Suministro", action = "SuministrosLista", pagina = 1, NumItems = 15 },
            //    new { pagina = @"\d+" }
            //    );

            routes.MapRoute(
                "ItemsPorPagina", "{controller}/{action}/{pagina}/{NumItems}",
                new { Controller = "Suministro", Action = "SuministrosLista", pagina = 1, NumItems =15}
                );
            //routes.MapRoute(
            //    null,
            //     "{NumItems}",
            //    defaults: new { Controller = "Suministro", action = "SuministrosLista", pagina=1}
            //);

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
        );



        }
    }
}
