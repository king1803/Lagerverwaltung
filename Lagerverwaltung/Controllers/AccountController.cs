using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lagerverwaltung.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Regestrieren()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Regestrieren(RegestrierenViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = "test@test.de"
                    
                };
                var result = await userManager.CreateAsync(user, model.Passwort);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if(await userManager.FindByNameAsync("ADMIN") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "ADMIN",
                    Email = "test@test.de"

                };
                await userManager.CreateAsync(user,"Passwort.123");

                IdentityRole identityRole = new IdentityRole
                {
                    Name = "Admin"
                };

                 await roleManager.CreateAsync(identityRole);
                user = await userManager.FindByNameAsync("ADMIN");
                await userManager.AddToRoleAsync(user,"Admin");
            }

            if (!(await userManager.HasPasswordAsync(await userManager.FindByNameAsync(model.User))) && model.Passwort == "Erst,20")
            {
                var model1 = new PasswortFestlegenViewModel
                {
                    User = model.User
                };
                return View("Passwortfestlegen", model1);
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var result = await signInManager.PasswordSignInAsync(model.User, model.Passwort, false, false);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("index", "home");
                    }

                    ModelState.AddModelError("", "Falscher User oder falsches Passwort");

                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult PasswortFestlegen(LoginViewModel model1)
        {
            PasswortFestlegenViewModel model = new PasswortFestlegenViewModel
            {
                User = model1.User
            };

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PasswortFestlegen(PasswortFestlegenViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.User);
                var result = await userManager.AddPasswordAsync(user,model.Passwort);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                
            }

            return View(model);
        }


        public IActionResult PasswortAendern()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswortAendern(PasswortAendernViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user1 = HttpContext.User;

                var user = await userManager.FindByNameAsync(user1.Identity.Name);

                var result = await userManager.ChangePasswordAsync(user, model.AltesPasswort, model.Passwort);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ausloggen ()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}