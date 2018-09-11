using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (sortBy.IsNullOrWhiteSpace())
                sortBy = "Name";

            var movieList = _context.Movies.Include(m => m.GenreType).ToList();

            return View(movieList);
        }

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var newMovieViewModel = new MovieFormViewModel()
            {
                GenreTypes = genreTypes,
                Movie = new Movie()
            };

            return View("MovieForm", newMovieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            else
            {
                var movieViewModel = new MovieFormViewModel()
                {
                    GenreTypes = _context.GenreTypes.ToList(),
                    Movie = movie
                };
                return View("MovieForm", movieViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);

                existingMovie.GenreTypeId = movie.GenreTypeId;
                existingMovie.Name = movie.Name;
                existingMovie.NumberInStock = movie.NumberInStock;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.DateAdded = movie.DateAdded;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}