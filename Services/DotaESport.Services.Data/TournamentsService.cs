using System.Linq;
using DotaESport.Services.Mapping;

namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;
    using DotaESport.Web.ViewModels.Tournaments;

    public class TournamentsService : ITournamentsService
    {
        private readonly IDeletableEntityRepository<Tournament> tournamentRepository;

        public TournamentsService(IDeletableEntityRepository<Tournament> tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        public async Task AddTournamentAsync(AddTournamentInputModel model)
        {
            var tournament = new Tournament
            {
                Name = model.Name,
                Image = model.Image,
                Logo = model.Logo,
                Status = model.Status,
                Tier = model.Tier,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PrizePool = model.PrizePool,
                Location = model.Location,
                Info = model.Info,
                TeamCapacity = model.TeamCapacity,
            };

            await this.tournamentRepository.AddAsync(tournament);
            await this.tournamentRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllTournaments<T>(int? count = null)
        {
            IQueryable<Tournament> query =
                this.tournamentRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var tournament = this.tournamentRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return tournament;
        }

        public T GetByName<T>(string name)
        {
            var tournament = this.tournamentRepository.All()
                .Where(x => x.Name.ToUpper() == name.ToUpper())
                .To<T>().FirstOrDefault();
            return tournament;
        }
    }
}
