namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Common.Repositories;

    public class Team : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        public string Location { get; set; }

        public string Region { get; set; }

        [Required]
        public string TeamCaptain { get; set; }

        public decimal? TotalEarnings { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<TournamentResult> Achievements { get; set; }

    }
}
