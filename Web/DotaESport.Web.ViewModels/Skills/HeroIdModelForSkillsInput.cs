namespace DotaESport.Web.ViewModels.Skills
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class HeroIdModelForSkillsInput : IMapFrom<HeroInfo>
    {
        public int Id { get; set; }
    }
}
