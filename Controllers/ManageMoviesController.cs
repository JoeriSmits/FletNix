using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace FletNix.Controllers
{
    public class ManageMoviesController : Controller
    {
        private IMovieRepository _repository;

        public ManageMoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public IActionResult Index([FromQuery]string from)
        {
            var fromInt = 0;
            int.TryParse(from, out fromInt);
            if (from != null && int.Parse(from) > 0)
            {
                ViewData["from"] = from;
                fromInt = int.Parse(from);
            }
            var titles = _repository.GetMovies(fromInt, 20);
            return View(titles);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete([FromForm]int movieId, [FromForm] int from)
        {
            if (movieId > 0)
            {
                _repository.RemoveMovieById(movieId, from);
            }
            object routeObjects = new {
                from = from
            };
            return RedirectToAction("Index", "ManageMovies", routeObjects);
        }

        [Authorize]
        public IActionResult Edit([FromQuery] int movieId)
        {
            return View();
        }
    }
}
