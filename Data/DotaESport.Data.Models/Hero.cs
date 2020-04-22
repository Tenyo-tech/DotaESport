namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Hero : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public string MainAttribute { get; set; }

    }
}
