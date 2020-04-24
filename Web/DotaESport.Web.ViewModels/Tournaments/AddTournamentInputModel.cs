using System.ComponentModel.DataAnnotations;

namespace DotaESport.Web.ViewModels.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AddTournamentInputModel : IMapTo<Tournament>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public string Logo { get; set; }

        [Required]
        public TournamentStatus Status { get; set; }

        [Required]
        public TournamentTier Tier { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal PrizePool { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Info { get; set; }

        public int TeamCapacity { get; set; }
    }
}
