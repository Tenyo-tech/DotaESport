using DotaESport.Web.ViewModels.Articles;

namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : BaseController
    {
        private readonly IItemsService itemsService;

        public ItemsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        public IActionResult All()
        {
            var viewModel = this.itemsService.GetAllItems<AllItemsViewModel>();

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var itemViewModel = this.itemsService.GetById<ItemViewModel>(id);

            if (itemViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(itemViewModel);
        }
    }
}
