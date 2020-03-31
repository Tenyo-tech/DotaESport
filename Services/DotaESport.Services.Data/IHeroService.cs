namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Heroes.InputModels;

    public interface IHeroService
    {
        Task AddHeroAsync(AddHeroInputModel model);

        Task<IEnumerable<T>> GetAllHeroes<T>();
    }
}
