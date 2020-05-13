using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspForum.Context;
using AspForum.Context.Entities;
using AspForum.API.ViewModels;

namespace AspForum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubricsController : ControllerBase
    {
        private readonly ForumContext _context;

        public RubricsController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/Rubrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RubricViewModel>>> GetRubrics()
        {
            return await _context.Rubrics.Select(rubric => new RubricViewModel(rubric)).ToListAsync();
        }

        // GET: api/Rubrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RubricViewModel>> GetRubric(int id)
        {
            var rubric = new RubricViewModel(await _context.Rubrics.FindAsync(id));

            if (rubric == null)
            {
                return NotFound();
            }

            return rubric;
        }

        // PUT: api/Rubrics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRubric(int id, Rubric rubric)
        {
            if (id != rubric.Id)
            {
                return BadRequest();
            }

            _context.Entry(rubric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubricExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rubrics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rubric>> PostRubric(Rubric rubric)
        {
            _context.Rubrics.Add(rubric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRubric", new { id = rubric.Id }, rubric);
        }

        // DELETE: api/Rubrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rubric>> DeleteRubric(int id)
        {
            var rubric = await _context.Rubrics.FindAsync(id);
            if (rubric == null)
            {
                return NotFound();
            }

            _context.Rubrics.Remove(rubric);
            await _context.SaveChangesAsync();

            return rubric;
        }

        private bool RubricExists(int id)
        {
            return _context.Rubrics.Any(e => e.Id == id);
        }
    }
}
