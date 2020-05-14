using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AspForum.Context
{
/*    public class ForumContextFactory : IDesignTimeDbContextFactory<ForumContext>
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
    }*/
}
