using System.ComponentModel.DataAnnotations;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Models.Enums;

    public class Player : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(60)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Region { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public Status Status { get; set; }

        public string Biography { get; set; }

        public string Dota2Info { get; set; }
    }
}
