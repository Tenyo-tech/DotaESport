namespace DotaESport.Web.ViewModels.Heroes.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AddHeroInfoInputModel : IMapTo<HeroInfo>
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Portrait { get; set; }

        public string Bio { get; set; }

        public decimal Str { get; set; }

        public decimal StrPerLvl { get; set; }

        public decimal Agi { get; set; }

        public decimal AgiPerLvl { get; set; }

        public decimal Int { get; set; }

        public decimal IntPerLvl { get; set; }

        public decimal MinDamage { get; set; }

        public decimal MaxDamage { get; set; }

        public double MovementSpeed { get; set; }

        public double Armor { get; set; }
    }
}
