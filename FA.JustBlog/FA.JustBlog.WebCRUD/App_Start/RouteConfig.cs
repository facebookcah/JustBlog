using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog.WebCRUD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FA.JustBlog.WebCRUD.Controllers" }
            );

            routes.MapRoute(
                "Post",
                "Post /{ year}/{ month}/{title }",
                new { controller = "Post", action = "Details" },
                new { year = @"\d{4}", month = @"\d{2}" },
                 namespaces: new[] { "FA.JustBlog.WebCRUD.Controllers" }

            );
            routes.MapRoute(
                "Category",
                "Category /{ name}/{title }",
                new { controller = "Category", action = "Details" },
                 namespaces: new[] { "FA.JustBlog.WebCRUD.Controllers" }


            );
            routes.MapRoute(
                "Tag",
                "Tag /{ name}/{title }",
                new { controller = "Tag", action = "Details" },
                 namespaces: new[] { "FA.JustBlog.WebCRUD.Controllers" }

            );

        }
    }
}
