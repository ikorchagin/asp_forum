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
    public class RubricsController : ControllerBase
    {
        private readonly IRubricsRepo _repo;

        public RubricsController(IRubricsRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetRubricViewModel>> Get()
        {
            var rubrics = _repo.GetRubrics();

            if (rubrics == null)
            {
                return BadRequest("Not found any rubrics");
            }

            return Ok(rubrics?.Select(x => new GetRubricViewModel(x)));
        }

        [HttpGet("{id}")]
        public ActionResult<GetRubricViewModel> GetRubricById(int id)
        {
            var rubric = _repo.GetRubric(id);

            if (rubric == null)
            {
                return NotFound("Not found rubric");
            }

            return Ok(new GetRubricViewModel(rubric));
        }

        [HttpPost]
        public ActionResult AddRubric(SetRubricViewModel rubric)
        {
            _repo.AddRubric(rubric.Name);
            _repo.SaveChanges();
            return Ok("Comment has been added successfully");
        }

        [HttpDelete("rubricId")]
        public ActionResult DeleteComment(int rubricId)
        {
            _repo.RemoveRubric(rubricId);
            _repo.SaveChanges();
            return Ok("Comment has been deleted successfully");
        }
    }
}