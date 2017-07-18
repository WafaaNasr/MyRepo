using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #region API'sActions
        //GET api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        //GET api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Movie movieToSave = Mapper.Map<MovieDto, Movie>(movie);
            _context.Movies.Add(movieToSave);
            try
            {
                _context.SaveChanges();
                movie.Id = movieToSave.Id;
            }
            catch (DbEntityValidationException exception)
            {

                throw exception;
            }

            return Created(Request.RequestUri + "/" + movie.Id, movie);
        }

        //PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movieDto.Id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {

                throw exception;
            }

            return Ok(movieDto.Id);
        }

        //Delete api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {

                throw exception;
            }

            return Ok();
        }
        #endregion
    }
}
