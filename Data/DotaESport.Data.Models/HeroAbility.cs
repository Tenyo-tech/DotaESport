namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class HeroAbility : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public int ManaCost { get; set; }

        public double Cooldown { get; set; }

        public string ImgURL { get; set; }

        public string VideoURL { get; set; }

        public string HeroId { get; set; }

        public Hero Hero { get; set; }

    }
}
