using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Logging;

namespace CoreDataStore.Data.Sqlite.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BloggingContext _context;
        private readonly ILogger _logger;

        public BlogRepository(BloggingContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
        }

        public List<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }
    }
}
