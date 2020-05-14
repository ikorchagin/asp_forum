using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace AspForum.Context
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Rubric> Rubrics { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
