using AspForum.Data.Models;

namespace AspForum.API.ViewModels
{
    public class GetCommentViewModel
    {
        public GetCommentViewModel(CommentModel comment)
        {
            Id = comment.Id;
            Text = comment.Text;
            UserId = comment.User.Id;
            PostDate = comment.PostDate.ToString("yyyy-MM-dd HH:mm");
        }
        public int Id { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public string PostDate { get; set; }
    }

    public class SetCommentViewModel
    {
        public string Text { get; set; }

        public int ArticleId { get; set; }
    }
}