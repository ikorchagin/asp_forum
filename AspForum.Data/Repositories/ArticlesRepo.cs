using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspForum.Context.Entities;
using AspForum.Context;
using AspForum.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Data.Repositories
{
    public interface IArticlesRepo : IDisposable
    {
        IEnumerable<ArticleModel> GetAllArticles();

        IEnumerable<ArticleModel> GetArticlesByRubric(int id);

        ArticleModel GetArticleById(int id);

        void AddArticle(string title, string text, int? rubricId, int userId);

        void DeleteArticle(int id);

        void SaveChanges();
    }

    public class ArticlesRepo : IArticlesRepo
    {
        private readonly ForumContext _context;

        public ArticlesRepo(ForumContext context)
        {         
            _context = context;
        }

        public void AddArticle(string title, string text, int? rubricId, int userId)
        {
            var article = new Article();
            article.Title = title;
            article.Text = text;
            article.RubricId = rubricId;
            article.UserId = userId;
            _context.Articles.AddAsync(article);
        }

        public async void DeleteArticle(int artileId)
        {
            var article = await _context.Articles.FindAsync(artileId);
            
            if (article == null)
            {
                return;
            }

            _context.Articles.Remove(article);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public IEnumerable<ArticleModel> GetAllArticles()
        {
            _context.Articles.Include(x => x.Rubric).Include(x => x.User).ToList();
            return _context.Articles?.Select(article => new ArticleModel(article));
        }

        public ArticleModel GetArticleById(int artileId)
        {
            _context.Articles.Include(x => x.Rubric).Include(x => x.User).ToList();
            var article = new ArticleModel(_context.Articles.Find(artileId));
            return article;
        }

        public IEnumerable<ArticleModel> GetArticlesByRubric(int rubricId)
        {
            _context.Articles.Include(x => x.Rubric).Include(x => x.User).ToList();
            return _context.Articles.Where(x => x.RubricId == rubricId)?.Select(x => new ArticleModel(x));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}