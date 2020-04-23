﻿namespace DotaESport.Web.ViewModels.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AddTeamInputModel : IMapTo<Team>
    {
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Location { get; set; }

        public string Region { get; set; }

        public string TeamCaptain { get; set; }

        public decimal? TotalEarnings { get; set; }
    }
}
