namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Data.Models;
    using DotaESport.Services.Data;
    using DotaESport.Services.Mapping;
    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using DotaESport.Web.ViewModels.Heroes.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HeroesController : BaseController
    {
        private readonly IHeroService heroService;
        private readonly ISkillsService skillsService;

        public HeroesController(IHeroService heroService,ISkillsService skillsService)
        {
            this.heroService = heroService;
            this.skillsService = skillsService;
        }

        public async Task<IActionResult> All()
        {
            var allHeroes = await this.heroService
                .GetAllHeroes<AllHeroesViewModel>();

            return this.View(allHeroes);
        }

        public IActionResult ByName(string name)
        {

            var viewModel = this.heroService.GetByName<HeroInfoViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Skills = this.skillsService.GetSkillsByHeroId<SkillViewModel>(viewModel.Id);
            ;
            return this.View(viewModel);
        }
    }
}
