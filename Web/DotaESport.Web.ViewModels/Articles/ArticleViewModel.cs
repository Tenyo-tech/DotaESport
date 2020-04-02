using Ganss.XSS;

namespace DotaESport.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IMapTo<Article>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImgUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<ArticleCommentViewModel> Comments { get; set; }
    }
}
