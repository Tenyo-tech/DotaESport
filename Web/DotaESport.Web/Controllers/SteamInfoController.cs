namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DotaESport.Common;
    using DotaESport.Data.Models;
    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.SteamInfo;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Win32;
    using OpenDotaDotNet;
    using Steam.Models.SteamCommunity;
    using SteamWebAPI2.Interfaces;
    using SteamWebAPI2.Utilities;

    public class SteamInfoController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ISteamInfoService steamInfoService;

        public SteamInfoController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ISteamInfoService steamInfoService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.steamInfoService = steamInfoService;
        }

        [Authorize]
        public async Task<IActionResult> SteamInfo()
        {

            var user = await this.userManager.GetUserAsync(this.User);
            var login = await this.userManager.GetLoginsAsync(user);
            var provKey = login[0].ProviderKey;

            var steamId64 = this.steamInfoService.GetSteamId64(provKey);

            var steamId32 = this.steamInfoService.Steam64ToSteam32(steamId64);

            var steamId32ToString = steamId32.ToString();


            var openDota = new OpenDotaApi();

            var player = await openDota.Players.GetPlayerByIdAsync(steamId32);
            ;
            var webInterfaceFactory = new SteamWebInterfaceFactory(GlobalConstants.SteamApiKey);
            ;

            var authserver = (steamId64 - 76561197960265728) & 1;
            var authid = (steamId64 - 76561197960265728 - authserver) / 2;
            var test = $"STEAM_0:{authserver}:{authid}";

            ;

            //var player = await openDota.Players.GetPlayerByIdAsync();

            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

            var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync(76561198053563088);


            var userInfo = new SteamInfoViewModel
            {
                SteamId = user.Id.ToString(),
                Username = steamId32ToString,
                Login = login[0].ProviderKey,
            };


            return this.View(userInfo);
        }
    }
}
