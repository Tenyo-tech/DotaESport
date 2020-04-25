namespace DotaESport.Web.ViewModels.GameplayUpdates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class GameplayUpdatesDropDownViewModel : IMapFrom<GameplayUpdate>
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
