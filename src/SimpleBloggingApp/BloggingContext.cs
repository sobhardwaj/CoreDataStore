using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleBloggingApp
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./coredatastore.sqlite");


            // optionsBuilder.UseSqlite(@"Data Source=D:\Documents\GitHub\CoreDataStore\src\SimpleBloggingApp\coredatastore.sqlite");    
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}