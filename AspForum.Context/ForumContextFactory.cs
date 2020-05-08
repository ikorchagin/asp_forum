using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AspForum.Context
{
    public class ForumContextFactory : IDesignTimeDbContextFactory<ForumContext>
    {
        private IOptions<ForumContextSettings> _options;
        public ForumContextFactory(IOptions<ForumContextSettings> options)
        {
            _options = options;
        }
        public ForumContext CreateDbContext(string[] args)
        {
            return new ForumContext(_options);
        }
    }
}