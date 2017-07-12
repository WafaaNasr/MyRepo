using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //TODO if need to add new Specific Route, in the order of Specific prior to the Generic as the Orders Matters
            routes.MapRoute("MoviesByReleaseDate", "movie/released/{year}/{month}",
                new { controller = "Movie", action = "GetByRelease" },
                //Adding Constraints on Parameters
                new {year=@"\d{4}",month=@"\d{2}" });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
