using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie { Name = "Sherk!!" };

            List<Customer> customers = new List<Customer>
                {
                    new Customer {Name = "Customer1"},
                    new Customer {Name = "Customer2"}
                };
            RandomMovieViewModel viewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };
            return View(viewModel);
        }
        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult GetByRelease(int year, int month)
        {
            return Content($"In Year:{year} and Month: {month}");
        }
        public ActionResult Index()
        {
            return View(new List<Movie> { new Movie { Id = 1, Name = "Sherk" }, new Movie { Id = 2, Name = "Sherk2" } });
        }

    }
}