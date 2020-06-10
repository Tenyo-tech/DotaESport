namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.GameplayUpdates;
    using DotaESport.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public class GameplayUpdatesController : AdministrationController
    {
        private readonly IGameplayUpdatesService gameplayUpdatesService;

        public GameplayUpdatesController(IGameplayUpdatesService gameplayUpdatesService)
        {
            this.gameplayUpdatesService = gameplayUpdatesService;
        }

        public IActionResult Add()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameplayUpdateInputModel model)
        {

            var updateId = await this.gameplayUpdatesService.AddUpdateAsync(model);

            return this.Redirect($"GameplayUpdates/ById/{updateId}");
        }
    }
}
