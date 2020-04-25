namespace DotaESport.Web.ViewModels.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;
    using DotaESport.Web.ViewModels.Players;

    public class TeamViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public string Location { get; set; }

        public string Region { get; set; }

        public string Coach { get; set; }

        public decimal? TotalEarnings { get; set; }

        public string TeamCaptain { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

    }
}
