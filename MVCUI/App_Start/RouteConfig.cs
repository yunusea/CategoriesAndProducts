using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( name: "categoryList", url: "CategoryList", defaults: new { controller = "Category", action = "Index" } );
            //routes.MapRoute( name: "addcategory", url: "AddCategory", defaults: new { controller = "Category", action = "Add" } );
            //routes.MapRoute( name: "updatecategory", url: "UpdateCategory/{Id}", defaults: new { controller = "Category", action = "Update", Id = "" } );
            routes.MapRoute( name: "productList", url: "ProductList", defaults: new { controller = "Product", action = "Index" } );
            routes.MapRoute( name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
