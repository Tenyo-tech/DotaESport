namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Heroes.ViewModels;
    using DotaESport.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : BaseController
    {
        private readonly IPlayersService playersService;

        public PlayersController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }


        public IActionResult All()
        {
            var viewModel = this.playersService.GetAllPlayers<AllPlayersViewModel>();

            return this.View(viewModel);
        }
    }
}
