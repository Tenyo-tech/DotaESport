using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using DotaESport.Data.Models;
using DotaESport.Services.Mapping;

namespace DotaESport.Web.ViewModels.Articles
{
    public class ArticleInNewsViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 300
                    ? content.Substring(0, 300) + "..."
                    : content;
            }
        }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}

