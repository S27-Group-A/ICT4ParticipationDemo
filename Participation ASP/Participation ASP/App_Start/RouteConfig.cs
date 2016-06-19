using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Participation_ASP
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
            routes.Add(new Route("Chat/Room", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new {Controller = "Chat", action = "Room"}),
                DataTokens = new RouteValueDictionary(new {scheme = "https"})
            });
            routes.MapRoute(
                name: "Room",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Chat", action = "Room", id = UrlParameter.Optional }
            );


        }
    }
}
