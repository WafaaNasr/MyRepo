using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        #endregion InitializeDispose

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

        public ActionResult Create()
        {
            var movieViewModel = new MovieViewModel { Genres = _applicationDbContext.Genre.ToList(), Movie = null };
            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movieViewModel = new MovieViewModel { Genres = _applicationDbContext.Genre.ToList(), Movie = _applicationDbContext.Movies.Single(m => m.Id == id) };

            return View("MovieForm", movieViewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _applicationDbContext.Movies.Add(movie);
            }
            else
            {
                var movieIndDb = _applicationDbContext.Movies.Single(m => m.Id == movie.Id);
                movieIndDb.GenreId = movie.GenreId;
                movieIndDb.Name = movie.Name;
                movieIndDb.ReleaseDate = movie.ReleaseDate;
                movieIndDb.NumberInStock = movie.NumberInStock;
            }
            try
            {
                _applicationDbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEntityValidation)
            {
                Console.Write(dbEntityValidation.Message);
                throw dbEntityValidation;
            }
            return RedirectToAction("Index");
        }

        #endregion ControllerActions
    }
}