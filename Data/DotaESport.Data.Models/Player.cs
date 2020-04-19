using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Common.Models;
using DotaESport.Data.Models.Enums;

namespace DotaESport.Data.Models
{
    public class Player : BaseDeletableModel<int>
    {
        public string NickName { get; set; }

        public string Name { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public string Image { get; set; }

        public Status Status { get; set; }

        public string Biography { get; set; }

        public string Dota2Info { get; set; }
    }
}
