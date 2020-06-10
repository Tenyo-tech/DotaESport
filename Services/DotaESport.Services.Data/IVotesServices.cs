namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesServices
    {
        Task VoteAsync(int articleId, string userId, bool IsUpVote);

        int GetVotes(int articleId);
    }
}
