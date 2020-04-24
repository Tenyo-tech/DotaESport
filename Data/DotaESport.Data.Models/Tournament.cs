using System.ComponentModel.DataAnnotations;
using DotaESport.Data.Models.Enums;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Tournament : BaseDeletableModel<int>
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

        public string Location { get; set; }

        public string Info { get; set; }

        public int TeamCapacity { get; set; }

        public ICollection<TournamentResult> Results { get; set; }

    }
}