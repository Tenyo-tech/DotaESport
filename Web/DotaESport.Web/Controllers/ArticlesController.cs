namespace DotaESport.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult ById(int id)
        {
            var articleViewModel = this.articlesService.GetById<ArticleViewModel>(id);
            if (articleViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(articleViewModel);
        }
    }
}
