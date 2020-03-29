using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data.Common.Models;

namespace DotaESport.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

