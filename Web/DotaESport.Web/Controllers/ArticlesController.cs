using DotaESport.Data.Models;
using DotaESport.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(IArticlesService articlesService,UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.userManager = userManager;
        }

        public IActionResult News(int page = 1)
        {
            var viewModel = new NewsViewModel
            {
                Articles =
                    this.articlesService.GetAll<ArticleInNewsViewModel>(),
            };

            return this.View(viewModel);
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


        public IActionResult Create()
        {
            var viewModel = new CreateArticleViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var articleId = await this.articlesService.CreateAsync(input, user.Id);
            this.TempData["InfoMessage"] = "Article created!";
            return this.RedirectToAction(nameof(this.ById), new {id = articleId});
        }
    }
}
