namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Models.Enums;

    public class Item : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ItemImage { get; set; }

        [Required]
        public string ItemBigImage { get; set; }

        [Required]
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