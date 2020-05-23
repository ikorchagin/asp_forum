using AspForum.Data.Models;

namespace AspForum.API.ViewModels
{
    public class SetArticleViewModel
    {
        public string Title { get; set; }

        public string Text { get; set; }
        
        public int? RubricId { get; set; }
    }
    
    public class GetArticleViewModel
    {
        public GetArticleViewModel(ArticleModel article)
        {
            Id = article.Id;
            Title = article.Title;
            Text = article.Text;
            PostDate = article.PostDate.ToString("yyyy-MM-dd HH:mm");
            RubricId = article.Rubric.Id;
            UserId = article.User.Id;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string PostDate { get; set; }

        public int? RubricId { get; set; }

        public int? UserId { get; set; }
    }
}