using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using FletNix.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace FletNix.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<FletNixUser> _signInManager;

        public AuthController(SignInManager<FletNixUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("About", "FletNix");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("About", "FletNix");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }
           
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "FletNix");
        }
    }
}
