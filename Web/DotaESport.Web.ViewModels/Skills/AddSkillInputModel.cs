using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DotaESport.Data.Models;
using DotaESport.Data.Models.Enums;
using DotaESport.Services.Mapping;

namespace DotaESport.Web.ViewModels.Skills
{
    public class AddSkillInputModel : IMapTo<Skill>
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

    }
}
