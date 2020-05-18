using System;
using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Data.Models
{
    public class ArticleModel
    {
        public ArticleModel(Article article)
        {
            if (article == null)
            {
                return;
            }
            Id = article.Id;
            Title = article.Title;
            Text = article.Text;
            PostDate = article.PostDate;
            Rubric = new RubricModel(article.Rubric);
            User = new UserModel(article.User);
            Comments = article.Comments?.Select(comment => new CommentModel(comment));
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public RubricModel Rubric { get; set; }

        public UserModel User { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}