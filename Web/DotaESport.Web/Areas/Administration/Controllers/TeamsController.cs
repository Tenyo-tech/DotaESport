namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Teams;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : AdministrationController
    {
        private readonly ITeamsServices teamsServices;

        public TeamsController(ITeamsServices teamsServices)
        {
            this.teamsServices = teamsServices;
        }

        public IActionResult Add()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamInputModel model)
        {
            await this.teamsServices.AddTeamAsync(model);

            return this.Redirect("/Teams/All");
        }
    }
}
