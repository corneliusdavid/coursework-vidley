using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.Models.DTOs;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        // GET: /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // POST: /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDTO.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movieDTO.Id), movieDTO);
            }
        }

        // POST: /api/movies/1
        [HttpPost]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var origMovie = _context.Movies.ToList().SingleOrDefault(m => m.Id == id);
                if (origMovie == null)
                    return NotFound();
                else
                {
                    Mapper.Map(movieDTO, origMovie);

                    _context.SaveChanges();

                    return Ok(movieDTO);
                }
            }
        }

        // POST: /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var origMovie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (origMovie == null)
                return NotFound();
            else
            {
                _context.Movies.Remove(origMovie);
                _context.SaveChanges();

                return Ok(Mapper.Map<Movie, MovieDTO>(origMovie));
            }
        }
    }
}
