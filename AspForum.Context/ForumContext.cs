using System;
using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Context
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        public DbSet<Rubric> Rubric { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
