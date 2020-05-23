using System.Collections.Generic;
using System.Linq;
using AspForum.API.ViewModels;
using AspForum.Context;
using AspForum.Context.Entities;
using AspForum.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspForum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepo _repo;

        public CommentsController(ICommentsRepo repo)
        {
            _repo = repo;
        }

        public ActionResult<GetCommentViewModel> Get()
        {
            throw null;
        }   

        [HttpGet("article/{articleId}")]
        public ActionResult<GetCommentViewModel> GetCommentsByArticle(int articleId)
        {
            var comments = _repo.GetArticleComments(articleId);

            if (comments == null)
            {
                return BadRequest("Not found any comments");
            }

            return Ok(comments?.Select(x => new GetCommentViewModel(x)));
        }

        [HttpGet("{id}")]
        public ActionResult<GetCommentViewModel> GetCommentById(int id)
        {
            var comment = _repo.GetComment(id);

            if (comment == null)
            {
                return NotFound("Not found comment");
            }

            return Ok(new GetCommentViewModel(comment));
        }

        [HttpPost]
        public ActionResult AddComment(SetCommentViewModel comment)
        {
            _repo.AddComment(comment.ArticleId, 1, comment.Text);
            _repo.SaveChanges();
            return Ok("Comment has been added successfully");
        }

        [HttpDelete("commentId")]
        public ActionResult DeleteComment(int commentId)
        {
            _repo.DeleteComment(commentId);
            _repo.SaveChanges();
            return Ok("Comment has been deleted successfully");
        }
    }
}