using DotaESport.Web.ViewModels.Heroes.ViewModels;
using DotaESport.Web.ViewModels.Players;

namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Teams;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : BaseController
    {
        private readonly ITeamsServices teamsServices;
        private readonly IPlayersService playersService;

        public TeamsController(ITeamsServices teamsServices,IPlayersService playersService)
        {
            this.teamsServices = teamsServices;
            this.playersService = playersService;
        }

        public IActionResult All()
        {
            var viewModel = this.teamsServices.GetAllTeams<AllTeamsViewModel>();

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.teamsServices.GetById<TeamViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult ByName(string name)
        {

            var viewModel = this.teamsServices.GetByName<TeamViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Players = this.playersService.GetByTeamId<PlayerViewModel>(viewModel.Id);
            ;
            return this.View(viewModel);
        }
    }
}
