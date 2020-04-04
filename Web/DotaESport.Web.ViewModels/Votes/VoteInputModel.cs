using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Web.ViewModels.Votes
{
    public class VoteInputModel
    {
        public int ArticleId { get; set; }

        public bool IsUpVote { get; set; }
    }
}
