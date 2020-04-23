namespace DotaESport.Web.ViewModels.Heroes.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AllHeroesViewModel : IMapFrom<Hero>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string MainAttribute { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
