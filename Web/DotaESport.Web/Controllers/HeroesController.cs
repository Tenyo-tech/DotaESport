﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaESport.Services.Data;
using DotaESport.Web.ViewModels.Heroes.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DotaESport.Web.Controllers
{
    public class HeroesController : BaseController
    {
        private readonly IHeroService heroService;

        public HeroesController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHeroInputModel model)
        {
            await this.heroService.AddHeroAsync(model);

            return this.Redirect("/");
        }
    }
}