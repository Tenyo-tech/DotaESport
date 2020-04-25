using DotaESport.Web.ViewModels.GameplayUpdates;
using Microsoft.AspNetCore.Mvc;

namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;

    public class GameplayUpdatesController : BaseController
    {
        private readonly IGameplayUpdatesService gameplayUpdatesService;

        public GameplayUpdatesController(IGameplayUpdatesService gameplayUpdatesService)
        {
            this.gameplayUpdatesService = gameplayUpdatesService;
        }

        public IActionResult ById(int id)
        {
            var updates = this.gameplayUpdatesService.GetAllUpdates<GameplayUpdatesDropDownViewModel>();

            var viewModel = this.gameplayUpdatesService.GetById<GameplayUpdateViewModel>(id);
            viewModel.Updates = updates;

            return this.View(viewModel);
        }

        public IActionResult LastUpdate()
        {

            var updateId = this.gameplayUpdatesService.GetIdOfLastUpdate();


            return this.RedirectToAction(nameof(this.ById), new { id = updateId });
        }
    }
}
