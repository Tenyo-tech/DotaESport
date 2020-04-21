using DotaESport.Data.Models;
using DotaESport.Services.Mapping;

namespace DotaESport.Web.ViewModels.Heroes.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddHeroInputModel : IMapTo<Hero>
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string MainAttribute { get; set; }
    }
}
