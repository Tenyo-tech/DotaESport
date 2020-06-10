namespace DotaESport.Web.ViewModels.GameplayUpdates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;
    using DotaESport.Web.ViewModels.Players;
    using Ganss.XSS;

    public class GameplayUpdateViewModel : IMapFrom<GameplayUpdate>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public int GameplayUpdateId { get; set; }

        public IEnumerable<GameplayUpdatesDropDownViewModel> Updates { get; set; }
    }
}