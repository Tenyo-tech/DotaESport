namespace DotaESport.Web.ViewModels.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AllTeamsViewModel : IMapFrom<Team>
    {
        public string Name { get; set; }

        public string Logo { get; set; }

        public string Location { get; set; }

        public string Region { get; set; }

        public decimal? TotalEarnings { get; set; }

        public ICollection<PlayersInTeamViewModel> Players { get; set; }
    }
}
