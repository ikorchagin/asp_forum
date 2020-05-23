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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesRepo _repo;

        public ArticlesController(IArticlesRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetArticleViewModel>> Get()
        {
            var articles = _repo.GetAllArticles();
            return Ok(articles.Select(x => new GetArticleViewModel(x)));
        }

        [HttpGet("rubric/{id}")]
        public ActionResult<IEnumerable<GetArticleViewModel>> GetByRubric(int id)
        {
            return Ok(_repo.GetArticlesByRubric(id)?.Select(x => new GetArticleViewModel(x)));
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<GetArticleViewModel>> GetById(int id)
        {
            var article = _repo.GetArticleById(id);

            if (article.Id == 0)
            {
                return NotFound();
            }

            return Ok(new GetArticleViewModel(article));
        }

        [HttpPost]
        public void Post([FromBody]SetArticleViewModel article)
        {
            _repo.AddArticle(article.Title, article.Text, article.RubricId, 1);
            _repo.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteArticle(id);
            _repo.SaveChanges();
        }
    }
}