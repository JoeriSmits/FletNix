using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using FletNix.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace FletNix.Controllers
{
    [RequireHttps]
    public class MovieAwardController : Controller
    {
        private IMovieRepository _repositoryMovie;
        private readonly IMovieAwardRepository _repositoryMovieAward;

        public MovieAwardController(IMovieRepository repositoryMovie, IMovieAwardRepository	repositoryMovieAward)
        {
            _repositoryMovie = repositoryMovie;
            _repositoryMovieAward = repositoryMovieAward;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index([FromQuery]string from)
        {
            var fromInt = 0;
            int.TryParse(from, out fromInt);
            if (from != null && int.Parse(from) > 0)
            {
                ViewData["from"] = from;
                fromInt = int.Parse(from);
            }
            var titles = await _repositoryMovie.GetMovies(fromInt, 20);
            return View(titles);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Award([FromQuery] int movie)
        {
            var vm = new AwardViewModel
            {
                movies = await _repositoryMovie.GetMovieById(movie)
            };
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Award(AwardViewModel vm, [FromForm] int movieId)
        {
            var award = new MovieAwards
            {
                movie_id = movieId,
                award = vm.award,
                result = vm.result,
                number_of_awards = vm.number_of_awards
            };

            _repositoryMovieAward.AddMovieAward(award);

            return RedirectToAction("Index", "MovieAward");
        } 
    }
}
