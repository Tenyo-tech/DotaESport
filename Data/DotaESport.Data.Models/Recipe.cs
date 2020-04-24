namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Recipe : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
