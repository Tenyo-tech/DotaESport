namespace DotaESport.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNet.Security.OpenId.Steam;
    using DotaESport.Data.Models;
    using DotaESport.Services.Data;
    using DotaESport.Web.ViewModels;
    using DotaESport.Web.ViewModels.Administration.Dashboard;
    using DotaESport.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using IndexViewModel = DotaESport.Web.ViewModels.Home.IndexViewModel;

    public class HomeController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(IArticlesService articlesService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.articlesService = articlesService;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
