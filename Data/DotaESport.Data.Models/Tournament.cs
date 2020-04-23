using DotaESport.Data.Models.Enums;

namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Tournament : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public TournamentStatus Status { get; set; }

        public TournamentTier Tier { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PrizePool { get; set; }

        public string Location { get; set; }

        public string Info { get; set; }

        public int TeamCapacity { get; set; }

        public ICollection<TournamentResult> Results { get; set; }

    }
}