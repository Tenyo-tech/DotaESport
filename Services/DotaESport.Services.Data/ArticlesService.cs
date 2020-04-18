using System.Linq;
using DotaESport.Services.Mapping;

namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;
    using DotaESport.Web.ViewModels.Articles;

    public class ArticlesService : IArticlesService
    {
        private const string NullOrEmptyImgURLErrorMessage = "Article Image URL is null or empty.";
        private const string NullOrEmptyTitleErrorMessage = "Article Title is null or empty.";
        private const string NullOrEmptyContentErrorMessage = "Article Content is null or empty.";

        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Article> query =
                this.articleRepository.All().OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(CreateArticleViewModel input, string userId)
        {
            if (string.IsNullOrEmpty(input.ImgUrl) || string.IsNullOrWhiteSpace(input.ImgUrl))
            {
                throw new ArgumentNullException(NullOrEmptyImgURLErrorMessage);
            }
            if (string.IsNullOrEmpty(input.Title) || string.IsNullOrWhiteSpace(input.Title))
            {
                throw new ArgumentNullException(NullOrEmptyTitleErrorMessage);
            }
            if (string.IsNullOrEmpty(input.Content) || string.IsNullOrWhiteSpace(input.Content))
            {
                throw new ArgumentNullException(NullOrEmptyContentErrorMessage);
            }

            var article = new Article
            {
                ImgUrl = input.ImgUrl,
                Title = input.Title,
                Content = input.Content,
                UserId = userId,

            };
            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            return article.Id;
        }

        public T GetById<T>(int id)
        {
            var article = this.articleRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return article;
        }

        public IEnumerable<T> GetArticlesByPage<T>(int? take = null, int skip = 0)
        {
            var articles = this.articleRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip);
            if (take.HasValue)
            {
                articles = articles.Take(take.Value);
            }

            return articles.To<T>().ToList();
        }

        public int GetCountOnAllArticles()
        {
            return this.articleRepository.All().Count();
        }
    }
}
