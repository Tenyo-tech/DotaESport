namespace DotaESport.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NewsViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<ArticlesInNewsViewModel> Articles { get; set; }
    }
}
