using System;
using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using AspForum.Data.Models;

namespace AspForum.Data.Repositories
{
    public interface ICommentsRepo : IDisposable
    {
         IEnumerable<CommentModel> GetArticleComments(int articleId);

         void AddComment(int articleId, int userId, string text);

         void DeleteComment(int commentId);

         CommentModel GetComment(int commentId);

        void SaveChanges();

    }

    public class CommentsRepo : ICommentsRepo
    {
        private readonly ForumContext _context;

        public CommentsRepo(ForumContext context)
        {
            _context = context;
        }
        public void AddComment(int articleId, int userId, string text)
        {
            var comment = new Comment();
            comment.ArticleId = articleId;
            comment.UserId = userId;
            comment.Text = text;
            _context.Comments.AddAsync(comment);
        }

        public async void DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            _context.Comments.Remove(comment);
        }

        public CommentModel GetComment(int commentId)
        {
            var comment = _context.Comments.Find(commentId);

            if (comment.Id <= 0)
            {
                return null;
            }
            
            return new CommentModel(comment);
        }

        public IEnumerable<CommentModel> GetArticleComments(int articleId)
        {
            var comments = _context.Comments.Where(x => x.ArticleId == articleId);
            
            if (comments.Count() <= 0)
            {
                return null;
            }

            return _context.Comments?.Where(x => x.ArticleId == articleId).Select(x => new CommentModel(x));
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}