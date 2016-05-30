using System.Collections.Generic;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Sqlite
{
    public class BloggingContext : DbContext
    {
        private readonly string sqlLiteConnection;

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public BloggingContext()
        {
            sqlLiteConnection = "Filename=./coredatastore.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlite(sqlLiteConnection);
          //  optionsBuilder.UseSqlite("Filename=./../../../../../data/coredatastore.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://github.com/aspnet/EntityFramework/issues/2805
            // modelBuilder.AddEntityConfigurationsFromAssembly(ass);

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Url).HasColumnType("varchar(250)");
            });
        }


        public DbSet<Blog> Blogs { get; set; }
       // public DbSet<Post> Posts { get; set; }
    }



    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
