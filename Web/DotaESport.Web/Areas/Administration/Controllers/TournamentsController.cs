using DotaESport.Web.ViewModels.Tournaments;

namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class TournamentsController : AdministrationController
    {
        private readonly ITournamentsService tournamentsService;

        public TournamentsController(ITournamentsService tournamentsService)
        {
            this.tournamentsService = tournamentsService;
        }

        public IActionResult Add()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTournamentInputModel model)
        {
            await this.tournamentsService.AddTournamentAsync(model);

            return this.Redirect("/Tournaments/All");
        }
    }
}
