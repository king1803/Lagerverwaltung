using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdministrationController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            UserVerwaltungViewModel model = new UserVerwaltungViewModel();

            model.Users = new List<Userberechtigung>();

            var users = userManager.Users;

            foreach (var user in users)
            {
                Userberechtigung b = new Userberechtigung
                {
                    Name = user.UserName
                };


                model.Users.Add(b);
            }

            for (int i = 0; i < model.Users.Count(); i++)
            {
                if (await userManager.IsInRoleAsync(await userManager.FindByNameAsync(model.Users[i].Name), "Admin"))
                {
                    model.Users[i].Admin = true;
                }
                if (!(await userManager.HasPasswordAsync(await userManager.FindByNameAsync(model.Users[i].Name))))
                {
                    model.Users[i].Zurücksetzten = true;
                }
            }

            return View(model);
        }

        public IActionResult Erstellen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Erstellen(RolleErstellenViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RollenName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {

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
        [AllowAnonymous]
        public async Task<IActionResult> UserErstellen(UserVerwaltungViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.UserName + "@test.de"

                };
                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);


        }

        public async Task<IActionResult> UserRollenBearbeiten(UserVerwaltungViewModel model)
        {

            foreach (var user in model.Users)
            {

                var user1 = await userManager.FindByNameAsync(user.Name);

                if (user.Admin)
                {
                    await userManager.AddToRoleAsync(user1, "Admin");
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user1, "Admin");
                }
                if (user.Zurücksetzten)
                {
                    await userManager.RemovePasswordAsync(user1);
                }
            }

            return View("Index", model);
        }

    }
}