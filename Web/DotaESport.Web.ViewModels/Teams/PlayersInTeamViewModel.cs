using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Models;
using DotaESport.Services.Mapping;

namespace DotaESport.Web.ViewModels.Teams
{
    public class PlayersInTeamViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Name { get; set; }
    }
}
