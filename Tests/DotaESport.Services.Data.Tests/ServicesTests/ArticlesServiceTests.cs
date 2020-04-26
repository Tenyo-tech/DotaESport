namespace DotaESport.Services.Data.Tests.ServicesTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using DotaESport.Data.Models;
    using DotaESport.Data.Repositories;
    using DotaESport.Services.Data.Tests.Common;
    using DotaESport.Services.Mapping;
    using DotaESport.Web.Controllers;
    using DotaESport.Web.ViewModels;
    using DotaESport.Web.ViewModels.Articles;
    using DotaESport.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class ArticlesServiceTests
    {
        private const int ItemsPerPage = 5;

        public ArticlesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            AutoMapperConfig.RegisterMappings(typeof(ArticleViewModel).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(typeof(ArticleViewModel).Assembly);
        }

        [Fact]
        public async Task TestGetCountOnAllArticlesMethod()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);

            for (int i = 0; i < 10; i++)
            {
                var inputModel = new CreateArticleViewModel
                {
                    ImgUrl = $"TT{i}{i * 2}asd",
                    Content = $"Ten{i}{i * 2}",
                    Title = $"Article{i}",
                };
                await articlesService.CreateAsync(inputModel, i.ToString());
            }

            var result = articlesService.GetCountOnAllArticles();

            Assert.Equal(10, result);
        }

        [Fact]
        public async Task TestCreateASyncMethod()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);

            for (int i = 0; i < 10; i++)
            {
                var inputModel = new CreateArticleViewModel
                {
                    ImgUrl = $"TT{i}{i * 2}asd",
                    Content = $"Ten{i}{i * 2}",
                    Title = $"Article{i}",
                };
                await articlesService.CreateAsync(inputModel, i.ToString());
            }

            var result = context.Articles.Count();

            Assert.Equal(10, result);
        }

        [Fact]
        public async Task TestCreateASyncMethodWithWrongData()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);

            var inputModel = new CreateArticleViewModel
            {
                ImgUrl = string.Empty,
                Content = string.Empty,
                Title = string.Empty,
            };

            // Act

            // Assert

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await articlesService.CreateAsync(inputModel, "1");
            });
        }

        [Fact]
        public async Task TestCreateASyncMethodReturnId()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);
            var articlesId = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                var inputModel = new CreateArticleViewModel
                {
                    ImgUrl = $"TT{i}{i * 2}asd",
                    Content = $"Ten{i}{i * 2}",
                    Title = $"Article{i}",
                };
                articlesId.Add(await articlesService.CreateAsync(inputModel, i.ToString()));
            }

            Assert.True(articlesId[1] is int);
        }

        [Fact]
        public void TestIndexArticleViewModel()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);
            var mockService = new Mock<IArticlesService>();

            mockService.Setup(x => x.GetAll<IndexArticleViewModel>(It.IsAny<int>())).Returns(new List<IndexArticleViewModel>
            {
                new IndexArticleViewModel {ImgUrl = "img.1", Title = "Team Nigma", Content = "Team Nigma"},
                new IndexArticleViewModel {ImgUrl = "img.2", Title = "Team Secret", Content = "Team Secret"},
                new IndexArticleViewModel {ImgUrl = "img.3", Title = "Virtus Pro", Content = "Virtus Pro"},
            });

            var controller = new HomeController(mockService.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task TestGetAllMethod()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);

            var seeder = new ArticlesTestsSeeder();

            for (int i = 0; i < 10; i++)
            {
                var inputModel = new CreateArticleViewModel
                {
                    ImgUrl = $"TT{i}{i * 2}asd",
                    Content = $"Ten{i}{i * 2}",
                    Title = $"Article{i}",
                };
                await articlesService.CreateAsync(inputModel, i.ToString());
            }

            var result = articlesService.GetAll<IndexArticleViewModel>();

            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async Task TestGetArticlesByPageMethod()
        {

            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);


            for (int i = 0; i < 10; i++)
            {
                var inputModel = new CreateArticleViewModel
                {
                    ImgUrl = $"TT{i}{i * 2}asd",
                    Content = $"Ten{i}{i * 2}",
                    Title = $"Article{i}",
                };
                await articlesService.CreateAsync(inputModel, i.ToString());
            }
            var result1 = articlesService.GetArticlesByPage<IndexArticleViewModel>(5, 5);
            var result2 = articlesService.GetArticlesByPage<IndexArticleViewModel>(5, 0);

            Assert.Equal(5, result2.Count());

            Assert.Equal(5, result1.Count());

        }

        [Fact]
        public async Task TestGetByIdMethod()
        {
            MapperInitializer.InitializeMapper();
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var articleRepository = new EfDeletableEntityRepository<Article>(context);

            var articlesService = new ArticlesService(articleRepository);

            var articlesId = new List<int>();

            var inputModel = new CreateArticleViewModel
            {
                ImgUrl = $"TT{2}{2 * 2}asd",
                Content = $"Ten{2}{2 * 2}",
                Title = $"Article{2}",
            };
            var id = await articlesService.CreateAsync(inputModel, "2");

            var articleId = articleRepository.All().First(x => x.Id == id);

            var article = articlesService.GetById<IndexArticleViewModel>(id);

            Assert.True(article != null);

            Assert.True(article.Id == id);
        }
    }
}
