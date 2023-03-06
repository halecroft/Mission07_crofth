using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission07_crofth.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07_crofth.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("MovieSubmitted", movie);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(movie);
            }

        }

        public IActionResult Podcasts()
        {
            return View("MyPodcasts");
        }

        public IActionResult MovieList()
        {
            ViewBag.Movies = _movieContext.Movies.Include(x => x.Category).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.MovieId == id);

            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit (Movie movie, int id)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View("MovieForm", movie);
            }
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
