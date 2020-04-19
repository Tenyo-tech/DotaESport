using DotaESport.Data.Models.Enums;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string ItemImage { get; set; }

        public ItemType Type { get; set; }

        public BasicItemType? BasicItemType { get; set; }

        public UpgradeItemType? ItemType { get; set; }

        public NeutralItemTier? ItemTier { get; set; }

        public int ItemGoldPrice { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

        public string Hint { get; set; }

        public string Lore { get; set; }

        public int? Cooldown { get; set; }

        public int? ManaCost { get; set; }

        public IEnumerable<Item> Recipe { get; set; }

    }
}