using System;
using System.Collections.Generic;
using System.Linq;
using AspForum.Context;
using AspForum.Context.Entities;
using AspForum.Data.Models;

namespace AspForum.Data.Repositories
{
    public interface IRubricsRepo : IDisposable
    {
        void AddRubric(string rubricName);

        void RemoveRubric(int rubricId);

        IEnumerable<RubricModel> GetRubrics();

        RubricModel GetRubric(int rubricId);

        void SaveChanges();
    }
    public class RubricsRepo : IRubricsRepo
    {
        private readonly ForumContext _context;

        public RubricsRepo(ForumContext context)
        {
            _context = context;
        }

        public void AddRubric(string rubricName)
        {
            var rubric = new Rubric();
            rubric.Name = rubricName;
            _context.Rubrics.AddAsync(rubric);
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public RubricModel GetRubric(int rubricId)
        {
            var rubric = _context.Rubrics.Find(rubricId);
            
            if (rubric.Id <= 0)
            {
                return null;
            }

            return new RubricModel(rubric);
        }

        public IEnumerable<RubricModel> GetRubrics()
        {
            var rubrics = _context.Rubrics;

            if (rubrics.Count() <= 0)
            {
                return null;
            }

            return rubrics?.Select(x => new RubricModel(x));
        }

        public async void RemoveRubric(int rubricId)
        {
            var rubric = await _context.Rubrics.FindAsync(rubricId);
            _context.Rubrics.Remove(rubric);
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }
    }
}