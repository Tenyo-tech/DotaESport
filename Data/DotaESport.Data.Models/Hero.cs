using System.ComponentModel.DataAnnotations;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Hero : BaseDeletableModel<string>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string MainAttribute { get; set; }

    }
}
