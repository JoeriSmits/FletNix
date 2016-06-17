using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FletNix.Models;
using Microsoft.AspNet.Authorization;

namespace FletNix.Controllers
{
    [RequireHttps]
    public class FletNixController : Controller
    {  
        private IFletNixRepository _repository;

        public FletNixController(IFletNixRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
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
