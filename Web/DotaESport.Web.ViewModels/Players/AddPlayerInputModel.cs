namespace DotaESport.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AddPlayerInputModel : IMapTo<ProPlayer>
    {
        [Required]
        [MaxLength(100)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string Region { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamDropDownViewModel> Teams { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Biography { get; set; }

        public string Dota2Info { get; set; }
    }
}
