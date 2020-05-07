using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AspForum.Context
{
    public class ForumContextFactory : IDesignTimeDbContextFactory<ForumContext>
    {
        public ForumContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ForumContext>();
            builder.UseSqlite("Data Source=forumDb.db;");
            return new ForumContext(builder.Options);
        }
    }
}