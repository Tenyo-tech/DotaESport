namespace DotaESport.Web.ViewModels.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class PlayersInTeamViewModel : IMapFrom<ProPlayer>
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Name { get; set; }
    }
}
