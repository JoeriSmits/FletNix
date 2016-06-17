using System;
using System.Collections;
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
    public class ManageMoviesController : Controller
    {
        private IMovieRepository _repositoryMovie;
        private IGenreRepository _repositoryGenre;
        private IPersonRepository _repositoryPerson;

        public ManageMoviesController(IMovieRepository repositoryMovie, IGenreRepository repositoryGenre, IPersonRepository repositoryPerson)
        {
            _repositoryMovie = repositoryMovie;
            _repositoryGenre = repositoryGenre;
            _repositoryPerson = repositoryPerson;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm]int movieId, [FromForm] int from)
        {
            if (movieId > 0)
            {
                await _repositoryMovie.RemoveMovieById(movieId);
            }
            object routeObjects = new {
                from = from
            };
            return RedirectToAction("Index", "ManageMovies", routeObjects);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([FromQuery] int movie)
        {
            var vm = new NewMovieModel();
            vm.genres = _repositoryGenre.GetAllGenres();
            vm.ListOfPeople = await _repositoryPerson.getAllPersons();
            vm.movie = await _repositoryMovie.GetAllMovieInfoById(movie);
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewMovieModel vm, [FromForm]int movieId)
        {
            _repositoryGenre.DeleteGenreByMovieId(movieId);
            await _repositoryMovie.RemoveMovieById(movieId);

                ICollection<Movie_Genre> movieGenres = new List<Movie_Genre>();
                ICollection<Movie_Director> movieDirectors = new List<Movie_Director>();
                ICollection<Movie_Cast> movieCasts = new List<Movie_Cast>();

                var rand = new Random();
                var random = rand.Next(400000, 1000000);

            if (vm.SubmitGenres != null)
            {
                foreach (var genre in vm.SubmitGenres)
                {
                    var movieGenre = new Movie_Genre
                    {
                        genre_name = genre,
                        movie_id = random
                    };
                    movieGenres.Add(movieGenre);
                }
            }

            if (vm.Directors != null)
            {
                foreach (var director in vm.Directors)
                {
                    var movieDirector = new Movie_Director
                    {
                        movie_id = random,
                        person_id = Convert.ToInt32(director)
                    };
                    movieDirectors.Add(movieDirector);
                }
            }


            if (vm.Cast != null)
            {
                foreach (var cast in vm.Cast)
                {
                    var movieCast = new Movie_Cast
                    {
                        movie_id = random,
                        person_id = Convert.ToInt32(cast),
                        role = "(Unknown)"
                    };
                    movieCasts.Add(movieCast);
                }
            }

            var movie = new Movie
                {
                    movie_id = random,
                    title = vm.Title,
                    duration = vm.Duration,
                    description = vm.Description,
                    publication_year = vm.Publication_year,
                    previous_part = vm.Previous_part,
                    price = vm.Price,
                    URL = vm.Url,
                    minimum_age = vm.Minimum_age,
                    Movie_Genre = movieGenres,
                    Movie_Director = movieDirectors,
                    Movie_Cast = movieCasts
                };

                try
                {
                    await _repositoryMovie.AddMovie(movie);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Something went wrong with adding the movie");
                }

            return RedirectToAction("Index", "ManageMovies");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> New()
        {
            var vm = new NewMovieModel();
            vm.genres = _repositoryGenre.GetAllGenres();
            vm.ListOfPeople = await _repositoryPerson.getAllPersons();
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(NewMovieModel vm)
        {
            if (ModelState.IsValid)
            {
                ICollection<Movie_Genre> movieGenres = new List<Movie_Genre>();
                ICollection<Movie_Director> movieDirectors = new List<Movie_Director>();
                ICollection<Movie_Cast> movieCasts = new List<Movie_Cast>();

                var rand = new Random();
                var random = rand.Next(400000, 1000000);

                foreach (var genre in vm.SubmitGenres)
                {
                    var movieGenre = new Movie_Genre
                    {
                        genre_name = genre,
                        movie_id = random
                    };
                    movieGenres.Add(movieGenre);
                }

                foreach (var director in vm.Directors)
                {
                    var movieDirector = new Movie_Director
                    {
                        movie_id = random,
                        person_id = Convert.ToInt32(director)
                    };
                    movieDirectors.Add(movieDirector);
                }

                foreach (var cast in vm.Cast)
                {
                    var movieCast = new Movie_Cast
                    {
                        movie_id = random,
                        person_id = Convert.ToInt32(cast),
                        role = "(Unknown)"
                    };
                    movieCasts.Add(movieCast);
                }

                var movie = new Movie
                {
                    movie_id = random,
                    title = vm.Title,
                    duration = vm.Duration,
                    description = vm.Description,
                    publication_year = vm.Publication_year,
                    previous_part = vm.Previous_part,
                    price = vm.Price,
                    URL = vm.Url,
                    minimum_age = vm.Minimum_age,
                    Movie_Genre = movieGenres,
                    Movie_Director = movieDirectors,
                    Movie_Cast = movieCasts
                };

                try
                {
                    await _repositoryMovie.AddMovie(movie);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Something went wrong with adding the movie");
                }
            }
            return RedirectToAction("New", "ManageMovies");
        }
    }
}
