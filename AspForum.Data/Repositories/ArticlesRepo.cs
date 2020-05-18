using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using AspForum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Data.Repositories
{
    public class ArticlesRepo : IArticlesRepo
    {
        private readonly ForumContext _context;

        public ArticlesRepo(ForumContext context)
        {
            _context = context;            
        }

        public IEnumerable<ArticleModel> GetAllArticles()
        {
            _context.Articles.Include(x => x.Rubric).Include(x => x.User).ToList();
            return _context.Articles.Select(article => new ArticleModel(article));
        }
    }
}