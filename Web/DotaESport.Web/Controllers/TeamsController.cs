﻿namespace DotaESport.Web.Controllers
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

        public TeamsController(ITeamsServices teamsServices)
        {
            this.teamsServices = teamsServices;
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
    }
}
