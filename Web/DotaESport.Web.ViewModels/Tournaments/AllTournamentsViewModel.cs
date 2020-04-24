namespace DotaESport.Web.ViewModels.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;

    public class AllTournamentsViewModel : IMapFrom<Tournament>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

        public TournamentStatus Status { get; set; }
    }
}
