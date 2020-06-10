namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Tournaments;
    using Microsoft.AspNetCore.Mvc;

    public class TournamentsController : BaseController
    {
        private readonly ITournamentsService tournamentsService;

        public TournamentsController(ITournamentsService tournamentsService)
        {
            this.tournamentsService = tournamentsService;
        }

        public IActionResult All()
        {
            var viewModel = this.tournamentsService.GetAllTournaments<AllTournamentsViewModel>();

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var itemViewModel = this.tournamentsService.GetById<TournamentViewModel>(id);

            if (itemViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(itemViewModel);
        }
    }
}
