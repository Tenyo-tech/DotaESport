using System.Linq;
using DotaESport.Services.Data;
using DotaESport.Web.ViewModels.Administration.Dashboard;
using DotaESport.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using IndexViewModel = DotaESport.Web.ViewModels.Home.IndexViewModel;

namespace DotaESport.Web.Controllers
{
    using System.Diagnostics;

    using DotaESport.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IArticlesService articlesService;

        public HomeController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index()
        {

            var viewModel = new IndexViewModel
            {
                Articles =
                    this.articlesService.GetAll<IndexArticleViewModel>(4),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult HttpError(int statusCode)
        {
            return this.View(statusCode);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
