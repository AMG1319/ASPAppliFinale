using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPAppliFinale
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
                name: "LoginMan",
                url: "Logins/LoginMan/{Email}/{Mdp}",
                defaults: new { controller = "Logins", action = "LoginMan", Email = UrlParameter.Optional, Mdp = UrlParameter.Optional }
            );
        }
    }
}
