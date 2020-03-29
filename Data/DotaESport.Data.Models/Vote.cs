namespace DotaESport.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DotaESport.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
