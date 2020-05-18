using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Data.Models
{
    public class RubricModel
    {
        public RubricModel(Rubric rubric)
        {
            if (rubric == null)
            {
                return;
            }
            Id = rubric.Id;
            Name = rubric.Name;
            Articles = rubric.Articles?.Select(article => new ArticleModel(article));
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}