namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Heroes.InputModels;

    public interface IHeroService
    {
        Task AddHeroAsync(AddHeroInfoInputModel model);

        Task<IEnumerable<T>> GetAllHeroes<T>();

        IEnumerable<T> GetAllHeroes2<T>();

        T GetByName<T>(string name);
    }
}
