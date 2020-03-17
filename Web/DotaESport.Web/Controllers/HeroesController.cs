using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotaESport.Web.Controllers
{
    public class HeroesController : BaseController
    {
        public HeroesController()
        {
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddHero()
        {

        }
    }
}
