namespace DotaESport.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Data.Models.Enums;
    using DotaESport.Services.Mapping;
    using Ganss.XSS;

    public class PlayerViewModel : IMapFrom<ProPlayer>
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string TeamName { get; set; }

        public string TeamImage { get; set; }

        public string Image { get; set; }

        public Status Status { get; set; }

        public string Biography { get; set; }

        public string SanitizedBiography => new HtmlSanitizer().Sanitize(this.Biography);

        public string Dota2Info { get; set; }
    }
}
