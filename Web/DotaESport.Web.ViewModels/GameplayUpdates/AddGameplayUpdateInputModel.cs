namespace DotaESport.Web.ViewModels.GameplayUpdates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class AddGameplayUpdateInputModel : IMapTo<GameplayUpdate>
    {
        public string Name { get; set; }

        public string Content { get; set; }
    }
}
