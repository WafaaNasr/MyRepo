using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Instead of Using the Old Custome Mapping use Allow Route Attribute 
            //TODO:1 Allow it 
            routes.MapMvcAttributeRoutes();
            

            /*2: Removethe OLd ONE And Add it on The respective Controller
             //if need to add new Specific Route, in the order of Specific prior to the Generic as the Orders Matters
            routes.MapRoute("MoviesByReleaseDate", "movie/released/{year}/{month}",
                new { controller = "Movie", action = "GetByRelease" },
                //Adding Constraints on Parameters
                new {year=@"\d{4}",month=@"\d{2}" });*/

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
