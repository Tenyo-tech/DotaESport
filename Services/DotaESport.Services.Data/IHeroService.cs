using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Web.ViewModels.Heroes.InputModels;

namespace DotaESport.Services.Data
{
    public interface IHeroService
    {
        Task AddHeroAsync(AddHeroInputModel model);

        Task<IEnumerable<T>> GetAllHeroes<T>();

    }
}
