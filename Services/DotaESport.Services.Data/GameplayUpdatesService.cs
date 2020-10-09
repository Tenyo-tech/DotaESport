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
    using DotaESport.Web.ViewModels.GameplayUpdates;

    public class GameplayUpdatesService : IGameplayUpdatesService
    {
        private readonly IDeletableEntityRepository<GameplayUpdate> gameplayRepository;

        public GameplayUpdatesService(IDeletableEntityRepository<GameplayUpdate> gameplayRepository)
        {
            this.gameplayRepository = gameplayRepository;
        }

        public async Task<int> AddUpdateAsync(AddGameplayUpdateInputModel model)
        {
            var update = new GameplayUpdate
            {
                Name = model.Name,
                Content = model.Content,
            };

            await this.gameplayRepository.AddAsync(update);
            await this.gameplayRepository.SaveChangesAsync();

            return update.Id;
        }

        public T GetById<T>(int id)
        {
            var update = this.gameplayRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return update;
        }

        public int GetIdOfLastUpdate()
        {
            var id = this.gameplayRepository
                .All()
                .OrderByDescending(x => x.Name)
                .Select(x => x.Id)
                .FirstOrDefault();
            return id;
        }

        public IEnumerable<T> GetAllUpdates<T>(int? count = null)
        {
            IQueryable<GameplayUpdate> query =
                this.gameplayRepository.All().OrderByDescending(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
