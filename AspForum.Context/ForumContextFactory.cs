using System.Linq;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace AspForum.Context
{
    public class ForumContextFactory : IDesignTimeDbContextFactory<ForumContext>
    {
        public ForumContext CreateDbContext(string[] args)
        {
            string projectPath = Directory.GetDirectories(Directory.GetParent(Directory.GetCurrentDirectory())
                .ToString()).Where(directory => directory.Contains("API")).SingleOrDefault();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<ForumContext>();
            builder.UseSqlite(connectionString);

            return new ForumContext(builder.Options);
        }
    }
}