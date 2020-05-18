using AspForum.Context.Entities;

namespace AspForum.Data.Models
{
    public class CommentModel
    {
        public CommentModel(Comment comment)
        {
            Id = comment.Id;
            Text = comment.Text;
            User = new UserModel(comment.User);
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public UserModel User { get; set; }
    }
}