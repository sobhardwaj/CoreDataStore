using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleBloggingApp
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./coredatastore.sqlite");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}