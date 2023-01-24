using MediaFaire.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Controllers
{

    
    public class AuthencationController : Controller
    {

        private readonly SignInManager<IdentityUser> signInManager;

        private readonly UserManager<IdentityUser> userManager;
        public AuthencationController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
     

        [HttpGet("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Account/Login")]
        public async Task<ActionResult> Login(Login model,string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);

             
                
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                        return RedirectToAction("Create", "Uploads");
                }

            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Regestair()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Regestair(Regeister model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

               var result = await userManager.CreateAsync(user, model.Password);
               if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, true);
                    return RedirectToAction("Create", "Uploads");
                }else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
                

            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
