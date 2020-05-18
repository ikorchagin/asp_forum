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
        private readonly IArticlesRepo _articlesRepo;

        public ArticlesController(IArticlesRepo articlesRepo)
        {
            _articlesRepo = articlesRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleViewModel>> Get()
        {
            return Ok(_articlesRepo.GetAllArticles().Select(x => new ArticleViewModel(x)));
        }
    }
}