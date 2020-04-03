using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotaESport.Services.Data
{
    public interface IVotesServices
    {
        Task VoteAsync(int postId, string userId, bool IsUpVote);
    }
}
