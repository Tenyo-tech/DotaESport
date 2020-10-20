namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.MongoDb.Data;
    using Microsoft.AspNetCore.Mvc;

    public class HeroesMongoDbController : BaseController
    {
        private readonly IHeroMongoDbService heroMongoDbService;

        public HeroesMongoDbController(IHeroMongoDbService heroMongoDbService)
        {
            this.heroMongoDbService = heroMongoDbService;
        }

        public IActionResult AllHeroesMongoDb()
        {
            this.heroMongoDbService.GetAllHeroes();

            return this.View();
        }
    }
}
