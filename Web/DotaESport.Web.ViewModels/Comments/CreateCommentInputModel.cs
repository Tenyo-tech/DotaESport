namespace DotaESport.Web.ViewModels.Comments
{
    public class CreateCommentInputModel
    {
        public int ArticleId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
