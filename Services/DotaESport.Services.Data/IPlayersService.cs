namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Players;

    public interface IPlayersService
    {
        Task AddPlayerAsync(AddPlayerInputModel model);

        T GetById<T>(int id);

        IEnumerable<T> GetByTeamId<T>(int teamId);

        IEnumerable<T> GetAllPlayers<T>(int? count = null);

    }
}