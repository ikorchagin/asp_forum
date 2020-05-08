using System.Data.Common;
using System;
using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspForum.Context
{
    public class ForumContext : DbContext
    {
        private IOptions<ForumContextSettings> _options;
        public ForumContext(IOptions<ForumContextSettings> options) : base(new DbContextOptionsBuilder<ForumContext>().Options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_options.Value.ConnectionString);
        }

        public DbSet<Rubric> Rubric { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
