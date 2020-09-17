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
    using DotaESport.Web.ViewModels.Items;
    using DotaESport.Web.ViewModels.Players;
    using Microsoft.EntityFrameworkCore;

    public class PlayersService : IPlayersService
    {
        private readonly IDeletableEntityRepository<ProPlayer> playerRepository;

        public PlayersService(IDeletableEntityRepository<ProPlayer> playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task AddPlayerAsync(AddPlayerInputModel model)
        {
            var player = new ProPlayer
            {
                NickName = model.NickName,
                Name = model.Name,
                Region = model.Region,
                Image = model.Image,
                Status = model.Status,
                TeamId = model.TeamId,
                Biography = model.Biography,
                Dota2Info = model.Dota2Info,
            };
            await this.playerRepository.AddAsync(player);
            await this.playerRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllPlayers<T>(int? count = null)
        {
            IQueryable<ProPlayer> query =
                this.playerRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var player = this.playerRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return player;
        }

        public IEnumerable<T> GetByTeamId<T>(int teamId)
        {
            var query = this.playerRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.TeamId == teamId);

            return query.To<T>().ToList();
        }

    }
}
