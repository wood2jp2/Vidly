using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre) ;
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            } else
            {
                return View(movie);
            }
        }

        public ActionResult New()
        {
            var genreNames = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genreNames
            };

            return View("NewMovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
             var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    return HttpNotFound();
                }

                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

            return View("EditMovie", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                var dateAdded = DateTime.Now;
                movie.DateAdded = dateAdded;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            // submitting a new movie is showing up as Genre = null and throwing exception
            // GenreId is correct, however
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("{0}/{1}", month, year));
        } 

        /* [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")] */ // attribute route with constraints

        public ActionResult Random()
        // GET: Movies/Random
        {

            var movie = new Movie() { Name = "Shrek!" };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
            };

            return View(viewModel);
            // var movie = new Movie() { Name = "Shrek!"};
            // return Content("josh says hi");
            // return HttpNotFound()
            // refer to helper methods
            // return new EmptyResult();
            // return View(movie); //first arg = Action, second = "route values"

        }

        //public ActionResult Edit(int id)
        //{
        //    return Content(string.Format("id: {0}", id));
        //}



    }
}
