using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using FletNix.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FletNix.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository _repositoryMovie;
        private IMemoryCache _memoryCache;
        private UserManager<FletNixUser> _userManager;
        private IWatchHistoryRepository _repositoryWatchHistory;
        private ICustomerFeedbackRepository _repositoryCustomerFeedback;

        public MovieController(IMovieRepository repositoryMovie, IWatchHistoryRepository repositoryWatchHistory, ICustomerFeedbackRepository repositoryCustomerFeedback,  UserManager<FletNixUser> userManager, IMemoryCache _memoryCache)
        {
            _repositoryCustomerFeedback = repositoryCustomerFeedback;
            _repositoryWatchHistory = repositoryWatchHistory;
            this._memoryCache = _memoryCache;
            this._repositoryMovie = repositoryMovie;
            this._userManager = userManager;
        }

        [Authorize]
        public IActionResult Overview([FromQuery] string search, [FromQuery] string from)
        {
            OverviewMovieViewModel watchMovieViewModel = new OverviewMovieViewModel();

            IEnumerable<Movie> movies;
            if (!_memoryCache.TryGetValue("populairMovies", out movies))
            {
                var populairMovies = _repositoryMovie.GetMostPopulairMovies();
                _memoryCache.Set("populairMovies", populairMovies,
                    new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
                movies = populairMovies;
            }
            watchMovieViewModel.populairMovies = movies;
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                var fromInt = 0;
                int.TryParse(from, out fromInt);
                if (from != null && int.Parse(from) > 0)
                {
                    ViewData["from"] = from;
                    fromInt = int.Parse(from);
                }
                ViewData["search"] = search;
                var searchedMovies = _repositoryMovie.GetMovieByTitle(search, fromInt);
                watchMovieViewModel.searchedMovies = searchedMovies;
            }

            return View(watchMovieViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Detail([FromQuery] string movie)
        {
            DetailedMovieViewModel _detailedMovieViewModel = new DetailedMovieViewModel();
            var idInt = 0;
            int.TryParse(movie, out idInt);
            _detailedMovieViewModel.detailedInformation = _repositoryMovie.GetMovieInfoById(idInt);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _detailedMovieViewModel.userWatchedMovie = _repositoryMovie.userWatchedMovie(idInt, user.Email);

            _detailedMovieViewModel.ratings = _repositoryCustomerFeedback.getCustomerFeedbackByMovieId(idInt);

            return View(_detailedMovieViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Watch([FromQuery] string movie)
        {
            var idInt = 0;
            int.TryParse(movie, out idInt);
            var detailInformation = _repositoryMovie.GetMovieById(idInt);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var test = _repositoryWatchHistory.AddWatchHistory(idInt, user);

            return View(detailInformation);
        }
    }
}
