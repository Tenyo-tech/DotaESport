using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Web.ViewModels.Articles
{
    public class NewsViewModel
    {
        public IEnumerable<ArticleInNewsViewModel> Articles { get; set; }
    }
}
