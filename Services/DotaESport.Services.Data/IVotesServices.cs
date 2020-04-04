using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotaESport.Services.Data
{
    public interface IVotesServices
    {
        Task VoteAsync(int articleId, string userId, bool IsUpVote);

        int GetVotes(int articleId);
    }
}
