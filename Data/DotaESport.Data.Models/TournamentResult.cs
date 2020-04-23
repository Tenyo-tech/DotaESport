using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Common.Models;
using DotaESport.Data.Models.Enums;

namespace DotaESport.Data.Models
{
    public class TournamentResult : BaseDeletableModel<int>
    {
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }

        public TournamentState TournamentState { get; set; }

        public int Position { get; set; }

        public int DPCPoints { get; set; }

        public decimal Reward { get; set; }
    }
}
