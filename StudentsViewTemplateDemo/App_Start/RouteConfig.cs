using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsViewTemplateDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable attribute routing
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Default",
                url: "",    
                defaults: new { controller = "Student", action = "GetAllStudents" }
            );


            routes.MapRoute(
                name: "Fallback",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "GetAllStudents", id = UrlParameter.Optional }
            );
        }
    }
}
