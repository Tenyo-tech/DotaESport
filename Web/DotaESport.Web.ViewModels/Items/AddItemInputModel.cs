namespace DotaESport.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AddItemInputModel : IMapTo<Item>
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public string ItemImage { get; set; }

        public string ItemBigImage { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        public BasicItemType? BasicItemType { get; set; }

        public UpgradeItemType? UpgradeItemType { get; set; }

        public NeutralItemTier? NeutralItemTier { get; set; }

        public int ItemGoldPrice { get; set; }

        public string DescriptionTitle { get; set; }

        [Required]
        public string Description { get; set; }

        public string Hint { get; set; }

        public string Lore { get; set; }

        public int? Cooldown { get; set; }

        public int? ManaCost { get; set; }

    }
}
