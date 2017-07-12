using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie { Name = "Sherk!!" };
            return View(movie);
        }
        public ActionResult GetByRelease(int year, int month)
        {
            return Content($"In Year:{year} and Month: {month}");
        }
    }
}