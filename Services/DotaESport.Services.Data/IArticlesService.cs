﻿namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        Task<int> CreateAsync(CreateArticleViewModel model, string userI);

        T GetById<T>(int id);
    }
}