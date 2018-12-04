using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WelfareDenmark.TrainingBuddy.Web.Models;



namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //
        // GET: /User/Register
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        //
        // POST: /User/Register
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                //if (!string.IsNullOrEmpty(model.IsEmployee))
                //{
                //    user.Claims.Add(new IdentityUserClaim<string>
                //    {
                //        ClaimType = "IsEmployee",
                //        ClaimValue = model.IsEmployee
                //    });

                //}

                var result = await _userManager.CreateAsync(user,
                    model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("PageOne", "FrontPage");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,
                            error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //
        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //
        // POST: /User/Login
        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
                else
                {
                        ModelState.AddModelError(string.Empty, "Forkert log ind information");        
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(FrontPageController.PageOne), "FrontPage");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}