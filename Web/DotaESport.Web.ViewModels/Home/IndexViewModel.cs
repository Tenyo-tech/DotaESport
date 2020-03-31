using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexArticleViewModel> Articles { get; set; }
    }
}
