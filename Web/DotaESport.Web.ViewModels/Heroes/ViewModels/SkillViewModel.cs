using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Models;
using DotaESport.Data.Models.Enums;
using DotaESport.Services.Mapping;
using Ganss.XSS;

namespace DotaESport.Web.ViewModels.Heroes.ViewModels
{
    public class SkillViewModel : IMapFrom<Skill>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string Ability { get; set; }

        public DamageType? DamageType { get; set; }

        public PierceSpellImmunity PierceSpellImmunity { get; set; }

        public string Affects { get; set; }

        public string Cooldown { get; set; }

        public string ManaCost { get; set; }
    }
}
