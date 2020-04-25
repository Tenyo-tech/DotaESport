namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class GameplayUpdate : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Content { get; set; }
    }
}
