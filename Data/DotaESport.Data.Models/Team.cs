namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;
    using DotaESport.Data.Common.Repositories;

    public class Team : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Location { get; set; }

        public string Region { get; set; }

        public int PlayerId { get; set; }

        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }

        public decimal TotalEarnings { get; set; }

        public ICollection<TournamentResult> Achievements { get; set; }

    }
}
