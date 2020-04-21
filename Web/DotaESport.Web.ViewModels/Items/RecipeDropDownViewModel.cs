namespace DotaESport.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class RecipeDropDownViewModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
