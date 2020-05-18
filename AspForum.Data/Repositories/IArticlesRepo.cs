using System.Collections.Generic;
using AspForum.Context.Entities;
using AspForum.Data.Models;

namespace AspForum.Data.Repositories
{
    public interface IArticlesRepo
    {
        IEnumerable<ArticleModel> GetAllArticles();
    }
}