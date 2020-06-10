namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly IDeletableEntityRepository<HeroInfo> heroInfoRepository;

        public HeroService(IDeletableEntityRepository<Hero> heroRepository,IDeletableEntityRepository<HeroInfo> heroInfoRepository)
        {
            this.heroRepository = heroRepository;
            this.heroInfoRepository = heroInfoRepository;
        }

        public async Task AddHeroAsync(AddHeroInfoInputModel model)
        {
            var hero = new HeroInfo()
            {
                Name = model.Name,
                Image = model.Image,
                Role = model.Role,
                Portrait = model.Portrait,
                Bio = model.Bio,
                Str = model.Str,
                StrPerLvl = model.StrPerLvl,
                Agi = model.Agi,
                AgiPerLvl = model.AgiPerLvl,
                Int = model.Int,
                IntPerLvl = model.IntPerLvl,
                MinDamage = model.MinDamage,
                MaxDamage = model.MaxDamage,
                MovementSpeed = model.MovementSpeed,
                Armor = model.Armor,
            };

            await this.heroInfoRepository.AddAsync(hero);
            await this.heroInfoRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllHeroes<T>() =>
            await this.heroRepository
                .AllAsNoTracking()
                .To<T>()
                .ToArrayAsync();

        public T GetByName<T>(string name)
        {
            var hero = this.heroInfoRepository.All()
                .Where(x => x.Name.ToUpper() == name.ToUpper())
                .To<T>().FirstOrDefault();
            return hero;
        }
    }
}
