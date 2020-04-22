namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class HeroInfo : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Role { get; set; }

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

        public ICollection<Skill> Skills { get; set; }
    }
}
