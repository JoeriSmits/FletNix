using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FletNix.Models;
using Microsoft.AspNet.Authorization;

namespace FletNix.Controllers
{
    public class FletNixController : Controller
    {  
        private IFletNixRepository _repository;

        public FletNixController(IFletNixRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            var genres = _repository.GetAllGenres();
            
            return View(genres);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
