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
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Article> query =
                this.articleRepository.All().OrderBy(x => x.Title);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(CreateArticleViewModel model, string userId)
        {
            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                VideoUrl = model.VideoUrl,
                ImgUrl = model.ImgUrl,
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
    }
}
