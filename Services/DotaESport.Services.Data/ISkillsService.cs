namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Heroes.InputModels;
    using DotaESport.Web.ViewModels.Skills;

    public interface ISkillsService
    {
        Task AddSkillAsync(AddSkillInputModel model, int heroId);

        IEnumerable<T> GetSkillsByHeroId<T>(int heroId);
    }
}
