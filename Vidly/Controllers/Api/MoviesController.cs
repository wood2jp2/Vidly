using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET - All Movies - /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            var moviesList = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return moviesList;
        }
        
        // GET - One Movie by ID - /api/movies/{id}
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // POST - A new movie - /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieToPost = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movieToPost);
            _context.SaveChanges();

            movieToPost.Id = movieDto.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieToPost.Id), movieDto);
        }

        // UPDATE - One movie - /api/movies/{id}
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieToUpdateInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToUpdateInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieToUpdateInDb);

            _context.SaveChanges();

        }

        // DELETE - One Movie - /api/movies/{id}
        [HttpDelete]
        public Movie DeleteMovie(int id)
        {
            var movieToDeleteInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToDeleteInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieToDeleteInDb);
            _context.SaveChanges();

            return movieToDeleteInDb;
        }

    }
}
