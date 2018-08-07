using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using Vidly.ActionFilters;

namespace Vidly.Controllers
{
    [MyActionFilter]
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

        public ViewResult Index()
        {
        
           if (User.IsInRole(RoleName.CanManageMovies)) {
                return View("List");
           }
           else {
                return View("ReadOnlyList");
           }
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreNames = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genreNames
            };

            ViewBag.FormType = "New";

            return View("NewMovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
             var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    return HttpNotFound();
                }

            var viewModel = new MovieFormViewModel(movie)
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                NumberInStock = movie.NumberInStock,
                GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };

            ViewBag.FormType = "Edit";

            return View("EditMovie", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {

            Console.WriteLine(movie);

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("NewMovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                DateTime now = DateTime.Today;
                movie.DateAdded = now;
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
