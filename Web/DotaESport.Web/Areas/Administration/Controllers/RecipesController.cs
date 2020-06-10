namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;

    public class RecipesController : AdministrationController
    {
        private readonly IItemsService itemsService;
        private readonly IRecipesService recipesService;

        public RecipesController(IItemsService itemsService, IRecipesService recipesService)
        {
            this.itemsService = itemsService;
            this.recipesService = recipesService;
        }

        
    }
}
