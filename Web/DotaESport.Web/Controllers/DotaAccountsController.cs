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
    using DotaESport.Web.ViewModels.DotaAccounts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SteamWebAPI2.Interfaces;
    using SteamWebAPI2.Utilities;

    public class DotaAccountsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISteamInfoService steamInfoService;

        public DotaAccountsController(UserManager<ApplicationUser> userManager, ISteamInfoService steamInfoService)
        {
            this.userManager = userManager;
            this.steamInfoService = steamInfoService;
        }

        [Authorize]
        public async Task<IActionResult> AccountSummary()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var login = await this.userManager.GetLoginsAsync(user);
            var provKey = login[0].ProviderKey;
            var steamId64 = this.steamInfoService.GetSteamId64(provKey);
            var steamId32 = this.steamInfoService.Steam64ToSteam32(steamId64);

            var webInterfaceFactory = new SteamWebInterfaceFactory(GlobalConstants.SteamApiKey);

            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

            var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync((ulong)steamId64);

            var viewModel = new DotaAccountsViewModel
            {
                Nickname = playerSummaryResponse.Data.Nickname,
            };

            return this.View(viewModel);
        }
    }
}
