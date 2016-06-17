using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using FletNix.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace FletNix.Controllers
{
    [RequireHttps]
    public class RateMovieController : Controller
    {
        private IWatchHistoryRepository _repositoryWatchHistory;
        private UserManager<FletNixUser> _userManager;
        private IMovieRepository _movieRepository;
        private ICustomerFeedbackRepository _repositoryCustomerFeedback;

        public RateMovieController(IWatchHistoryRepository repositoryWatchHistory, IMovieRepository movieRepository, ICustomerFeedbackRepository repositoryCustomerFeedback, UserManager<FletNixUser> userManager )
        {
            _repositoryCustomerFeedback = repositoryCustomerFeedback;
            _movieRepository = movieRepository;
            _userManager = userManager;
            _repositoryWatchHistory = repositoryWatchHistory;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var rateViewModel = new RateViewModel();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            rateViewModel.WatchHistories = await _repositoryWatchHistory.getWatchHistoryByCustomer(user.Email);
            rateViewModel.CustomerFeedback = await _repositoryCustomerFeedback.getCustomerFeedbackByCustomer(user.Email);

            return View(rateViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Rate([FromQuery] string movie)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var record = await _repositoryWatchHistory.getWatchHistoryByCustomer(user.Email);

            var idInt = 0;
            int.TryParse(movie, out idInt);
            if (record.Any(w => w.movie_id == idInt))
            {
                var _movie = await _movieRepository.GetMovieById(idInt);
                return View(_movie);
            }
            else
            {
                return RedirectToAction("Index", "RateMovie");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromForm] int rating, [FromForm] string comment, [FromForm] int movieId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if ((rating >= 1 && rating <= 10) && !string.IsNullOrWhiteSpace(comment))
            {
                await _repositoryCustomerFeedback.addCustomerFeedback(user, rating, comment, movieId);
            }
            return RedirectToAction("Index", "RateMovie");
        }
    }
}
