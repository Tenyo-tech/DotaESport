namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;
    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using Microsoft.EntityFrameworkCore;

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
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                ImgUrl = model.ImgUrl,
                MainAttribute = model.MainAttribute,
            };

            await this.heroRepository.AddAsync(hero);
            await this.heroRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllHeroes<T>() =>
            await this.heroRepository
                .AllAsNoTracking()
                .To<T>()
                .ToArrayAsync();
    }
}
