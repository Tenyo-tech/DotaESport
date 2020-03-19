using DotaESport.Web.ViewModels.Heroes.InputModels;

namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;

    public class HeroService : IHeroService
    {
        private readonly IDeletableEntityRepository<Hero> heroRepository;

        public HeroService(IDeletableEntityRepository<Hero> heroRepository)
        {
            this.heroRepository = heroRepository;
        }

        public async Task AddHeroAsync(AddHeroInputModel model)
        {
            var hero = new Hero
            {
                Name = model.Name,
                ImgUrl = model.ImgUrl,
                MainAttribute = model.MainAttribute,
            };

            await this.heroRepository.AddAsync(hero);
            await this.heroRepository.SaveChangesAsync();
        }
    }
}
