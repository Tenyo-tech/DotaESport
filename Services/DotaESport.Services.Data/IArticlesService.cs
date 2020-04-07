namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(CreateArticleViewModel model, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetArticlesByPage<T>(int? take = null, int skip = 0);


        int GetCountOnAllArticles();

    }
}
