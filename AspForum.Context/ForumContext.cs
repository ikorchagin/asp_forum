using AspForum.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspForum.Context
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Rubric> Rubrics { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}