namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content, int? parentId = null);

        bool IsInArticleId(int commentId, int postId);
    }
}
