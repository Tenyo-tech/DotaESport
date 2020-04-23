using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Data.Common.Repositories;
using DotaESport.Data.Models;
using DotaESport.Services.Mapping;
using DotaESport.Web.ViewModels.Skills;

namespace DotaESport.Services.Data
{
    public class SkillsService : ISkillsService
    {
        private readonly IDeletableEntityRepository<Skill> skillsRepository;

        public SkillsService(IDeletableEntityRepository<Skill> skillsRepository)
        {
            this.skillsRepository = skillsRepository;
        }

        public async Task AddSkillAsync(AddSkillInputModel model,int heroId)
        {
            var skill = new Skill
            {
                Name = model.Name,
                Image = model.Image,
                Description = model.Description,
                Ability = model.Ability,
                DamageType = model.DamageType,
                PierceSpellImmunity = model.PierceSpellImmunity,
                Affects = model.Affects,
                Cooldown = model.Cooldown,
                ManaCost = model.ManaCost,
                HeroInfoId = heroId,
            };
            var id = heroId;
            await this.skillsRepository.AddAsync(skill);
            await this.skillsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetSkillsByHeroId<T>(int heroId)
        {
            var skills = this.skillsRepository.All()
                .OrderBy(x => x.CreatedOn)
                .Where(x => x.HeroInfoId == heroId);
            return skills.To<T>().ToList();
        }
    }
}
