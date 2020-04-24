namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Teams;

    public interface ITeamsServices
    {
        Task AddTeamAsync(AddTeamInputModel model);

        IEnumerable<T> GetAllTeams<T>(int? count = null);

        T GetById<T>(int id);

        T GetByName<T>(string name);
    }
}
