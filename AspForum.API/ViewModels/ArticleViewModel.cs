using AspForum.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.API.ViewModels
{
    public class ArticleViewModel
    {
        public ArticleViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            Text = article.Text;
            PostDate = article.PostDate.ToString("yyyy-MM-dd");
            RubricName = article.Rubric.Name;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string PostDate { get; set; }

        public string RubricName { get; set; }
    }
}
