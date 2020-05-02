using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_forum.API.Contexts;
using asp_forum.API.Entities;
using asp_forum.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asp_forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;
        private readonly ForumContext _db;

        public ArticlesController(ILogger<ArticlesController> logger, ForumContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ArticleViewModel> Get()
        {
            _db.Rubrics.Include(rubric => rubric.Articles).ToList();
            return _db.Articles.Select(article => new ArticleViewModel(article));
        }
    }
}