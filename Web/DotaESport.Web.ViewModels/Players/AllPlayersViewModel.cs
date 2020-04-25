﻿namespace DotaESport.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AllPlayersViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Name { get; set; }

        public string TeamName { get; set; }

        public string Region { get; set; }
    }
}
