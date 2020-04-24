using System.ComponentModel.DataAnnotations;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Models.Enums;

    public class Skill : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        public string Ability { get; set; }

        public DamageType? DamageType { get; set; }

        public PierceSpellImmunity PierceSpellImmunity { get; set; }

        public string Affects { get; set; }

        public string Cooldown { get; set; }

        public string ManaCost { get; set; }

        [Required]
        public int HeroInfoId { get; set; }

        public HeroInfo HeroInfo { get; set; }
    }
}
