namespace DotaESport.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using DotaESport.Data.Models;
    using DotaESport.Services.Mapping;
    using Ganss.XSS;

    public class ArticleViewModel : IMapFrom<Article>, IMapTo<Article>, IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.VotesCount, options => { options.MapFrom(a => a.Votes
                    .Sum(v => (int) v.Type)); });
        }
    }
}
