﻿namespace DotaESport.Web.ViewModels.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AddTournamentInputModel : IMapTo<Tournament>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Logo { get; set; }

        public TournamentStatus Status { get; set; }

        public TournamentTier Tier { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PrizePool { get; set; }

        public string Location { get; set; }

        public string Info { get; set; }

        public int TeamCapacity { get; set; }
    }
}
