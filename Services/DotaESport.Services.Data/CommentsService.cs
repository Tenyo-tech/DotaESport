namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(
            IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int articleId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                ArticleId = articleId,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInArticleId(int commentId, int articleId)
        {
            var commentArticleId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.ArticleId).FirstOrDefault();
            return commentArticleId == articleId;
        }
    }
}
