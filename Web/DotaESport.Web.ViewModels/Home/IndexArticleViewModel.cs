namespace DotaESport.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class IndexArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string ImgUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int PostsCount { get; set; }
    }
}