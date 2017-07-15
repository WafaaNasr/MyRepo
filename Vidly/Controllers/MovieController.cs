using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        #region InitializeDispose

        private readonly ApplicationDbContext _applicationDbContext;

        public MovieController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _applicationDbContext.Dispose();
        }

        #endregion
        #region ControllerActions
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
            return View(_applicationDbContext.Movies.Include(m => m.Genre).ToList());
        }

        public ActionResult Detail(int id)
        {
            var movie = _applicationDbContext.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return movie == null ? (ActionResult)HttpNotFound() : View(movie);
        }
        #endregion
    }
}