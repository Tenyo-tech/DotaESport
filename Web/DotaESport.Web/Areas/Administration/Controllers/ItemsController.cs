namespace DotaESport.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : AdministrationController
    {
        private readonly IItemsService itemsService;
        private readonly IRecipesService recipesService;

        public ItemsController(IItemsService itemsService, IRecipesService recipesService)
        {
            this.itemsService = itemsService;
            this.recipesService = recipesService;
        }

        public IActionResult AddItem()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemInputModel model)
        {
            await this.itemsService.AddItemAsync(model);

            return this.Redirect("/Items/All");
        }
    }
}
