namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.GameplayUpdates;
    using DotaESport.Web.ViewModels.Players;

    public interface IGameplayUpdatesService
    {
        Task<int> AddUpdateAsync(AddGameplayUpdateInputModel model);

        T GetById<T>(int id);

        int GetIdOfLastUpdate();

        IEnumerable<T> GetAllUpdates<T>(int? count = null);
    }
}
