using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Web.ViewModels.Articles
{
    public class NewsViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<ArticlesInNewsViewModel> Articles { get; set; }
    }
}
