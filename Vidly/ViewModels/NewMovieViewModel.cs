using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;


namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie;
        public IEnumerable<Genre> Genres { get; set; }

    }
}