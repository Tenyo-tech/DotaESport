using DotaESport.Common;
using Microsoft.AspNetCore.Authorization;

namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using DotaESport.Web.ViewModels.Skills;
    using Microsoft.AspNetCore.Mvc;

    public class SkillsController : AdministrationController
    {
        public static int HeroId;
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        [Authorize]
        public IActionResult Add(int heroInfoId)
        {
            HeroId = heroInfoId;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddSkillInputModel model)
        {
            var heroInfoId = HeroId;
            await this.skillsService.AddSkillAsync(model,heroInfoId);

            return this.Redirect("/Heroes/All");
        }
    }
}
