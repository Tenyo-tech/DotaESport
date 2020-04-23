namespace DotaESport.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AddPlayerInputModel : IMapTo<Player>
    {
        public string NickName { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        public IEnumerable<TeamDropDownViewModel> Teams { get; set; }

        public string Image { get; set; }

        public Status Status { get; set; }

        public string Biography { get; set; }

        public string Dota2Info { get; set; }
    }
}
