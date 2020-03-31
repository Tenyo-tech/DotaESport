namespace DotaESport.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public string ImgUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

    }
}
