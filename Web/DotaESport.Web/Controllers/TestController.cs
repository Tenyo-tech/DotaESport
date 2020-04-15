using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotaESport.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Test()
        {
            var result = await this.roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin",
            });
            var user = await this.userManager.GetUserAsync(this.User);
            var user2 = await this.userManager.FindByNameAsync("Tenyo@abv.bg");
            await this.userManager.AddToRoleAsync(user2, "Admin");

            return this.Json(result);
        }
    }
}
