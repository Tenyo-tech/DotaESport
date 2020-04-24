namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Tournaments;

    public interface ITournamentsService
    {
        Task AddTournamentAsync(AddTournamentInputModel model);

        IEnumerable<T> GetAllTournaments<T>(int? count = null);

        T GetById<T>(int id);

        T GetByName<T>(string name);
    }
}
