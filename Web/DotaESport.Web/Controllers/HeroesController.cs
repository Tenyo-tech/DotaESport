﻿namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using DotaESport.Web.ViewModels.Heroes.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HeroesController : BaseController
    {
        private readonly IHeroService heroService;

        public HeroesController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        public async Task<IActionResult> All()
        {
            var allHeroes = await this.heroService
                .GetAllHeroes<AllHeroesViewModel>();

            return this.View(allHeroes);
        }
    }
}
