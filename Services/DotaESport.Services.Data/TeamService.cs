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
    using DotaESport.Web.ViewModels.Teams;

    public class TeamService : ITeamsServices
    {
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public TeamService(IDeletableEntityRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task AddTeamAsync(AddTeamInputModel model)
        {
            var team = new Team
            {
                Name = model.Name,
                Logo = model.Logo,
                Location = model.Location,
                Region = model.Region,
                TeamCaptain = model.TeamCaptain,
                TotalEarnings = model.TotalEarnings,
            };

            await this.teamRepository.AddAsync(team);
            await this.teamRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllTeams<T>(int? count = null)
        {
            IQueryable<Team> query =
                this.teamRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var item = this.teamRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return item;
        }
    }
}
