namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using AspNet.Security.OpenId.Steam;
    using DotaESport.Data.Models;
    using DotaESport.Web.ViewModels.Home;
    using Facebook;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Server.HttpSys;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Linq;

    public class TestsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public TestsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> Test()
        {
            StringBuilder sb = new StringBuilder();

            var user = await this.userManager.GetUserAsync(this.User);

            var steamAuthenticationOptions = new SteamAuthenticationOptions();

            var item1 = steamAuthenticationOptions.ApplicationKey;
            var item2 = steamAuthenticationOptions.UserInformationEndpoint.FirstOrDefault().ToString();
            var item3 = steamAuthenticationOptions.UserInformationEndpoint;
            var item4 = SteamAuthenticationConstants.Parameters.Name;
            var item5 = SteamAuthenticationConstants.Parameters.SteamId;
            //var item6 = SteamAuthenticationConstants.Parameters.Key;
            //var item7 = SteamAuthenticationConstants.Parameters.Players;
            //var item8 = SteamAuthenticationConstants.Parameters.Response;
            //var item9 = SteamAuthenticationConstants.Namespaces.Identifier;
            //var item10 = SteamAuthenticationConstants.Namespaces.LegacyIdentifier;
            //
            //var item11 = SteamAuthenticationDefaults.UserInformationEndpoint;
            //var item12 = SteamAuthenticationDefaults.Authority;
            //var item13 = SteamAuthenticationDefaults.DisplayName;
            //var item14 = SteamAuthenticationDefaults.AuthenticationScheme;
            //var item15 = SteamAuthenticationDefaults.CallbackPath;

            foreach (var item in item5)
            {
                var asd = item;
            }

            var info1 = this.userManager.GetUserAsync(this.User);

            return this.View();
        }

    }
}
