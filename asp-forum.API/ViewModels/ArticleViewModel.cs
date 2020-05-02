using asp_forum.API.Contexts;
using asp_forum.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_forum.API.ViewModels
{
    public class ArticleViewModel
    {
        public ArticleViewModel(Article article)
        {
            Title = article.Title;
            Text = article.Text;
            RubricName = article.Rubric?.Name;
            PostDate = article.PostDate.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }
        public string Title { get; }

        public string Text { get; }

        public string RubricName { get; }

        public string PostDate { get; }
    }
}
