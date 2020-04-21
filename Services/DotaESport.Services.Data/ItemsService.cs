using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Data.Common.Repositories;
using DotaESport.Data.Models;
using DotaESport.Data.Models.Enums;
using DotaESport.Services.Mapping;
using DotaESport.Web.ViewModels.Items;
using Microsoft.EntityFrameworkCore;

namespace DotaESport.Services.Data
{
    public class ItemsService : IItemsService
    {
        private readonly IDeletableEntityRepository<Item> itemRepository;

        public ItemsService(IDeletableEntityRepository<Item> itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task AddItemAsync(AddItemInputModel model)
        {
            var item = new Item
            {
                Name = model.Name,
                ItemImage = model.ItemImage,
                ItemType = model.ItemType,
                BasicItemType = model.BasicItemType,
                UpgradeItemType = model.UpgradeItemType,
                NeutralItemTier = model.NeutralItemTier,
                ItemGoldPrice = model.ItemGoldPrice,
                DescriptionTitle = model.DescriptionTitle,
                Description = model.Description,
                Hint = model.Hint,
                Lore = model.Lore,
                Cooldown = model.Cooldown,
                ManaCost = model.ManaCost,
            };

            await this.itemRepository.AddAsync(item);
            await this.itemRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllItems<T>(int? count = null)
        {
            IQueryable<Item> query =
                this.itemRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

    }
}
