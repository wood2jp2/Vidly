using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Edit(int id)
        {
            return Content(string.Format("id: {0}", id));
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex: {0}, sortBy: {1}", pageIndex, sortBy));
        }

        public ActionResult Hello() // 'Hello' would be in this case what is returned when '/Movies/Hello' is hit
        {
            return Content(string.Format("Hello, my name is {0}", "Josh"));
        }

    }
}
