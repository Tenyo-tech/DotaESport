namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using DotaESport.Web.ViewModels.Players;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController :AdministrationController
    {
        private readonly IPlayersService playersService;
        private readonly ITeamsServices teamsServices;

        public PlayersController(IPlayersService playersService,ITeamsServices teamsServices)
        {
            this.playersService = playersService;
            this.teamsServices = teamsServices;
        }

        public IActionResult Add()
        {
            var teams = this.teamsServices.GetAllTeams<TeamDropDownViewModel>();
            var viewModel = new AddPlayerInputModel
            {
                Teams = teams,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlayerInputModel model)
        {
            var teamId = model.TeamId;

            await this.playersService.AddPlayerAsync(model);

            return this.Redirect("/Players/All");
        }
    }
}
