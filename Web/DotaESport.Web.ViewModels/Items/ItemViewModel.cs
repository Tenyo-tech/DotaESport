using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Models;
using DotaESport.Data.Models.Enums;
using DotaESport.Services.Mapping;

namespace DotaESport.Web.ViewModels.Items
{
    public class ItemViewModel : IMapFrom<Item>
    {
        public string Name { get; set; }

        public string ItemImage { get; set; }

        public ItemType ItemType { get; set; }

        public BasicItemType? BasicItemType { get; set; }

        public UpgradeItemType? UpgradeItemType { get; set; }

        public NeutralItemTier? NeutralItemTier { get; set; }

        public int ItemGoldPrice { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

        public string Hint { get; set; }

        public string Lore { get; set; }

        public int? Cooldown { get; set; }

        public int? ManaCost { get; set; }
    }
}
