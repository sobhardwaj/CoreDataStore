using Microsoft.EntityFrameworkCore;
using SimpleBloggingApp.Entities;

namespace SimpleBloggingApp
{
    public class BloggingContext : DbContext
    {
        private readonly string sqlLiteConnection; 

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

        public BloggingContext()
        {
            sqlLiteConnection = "Filename=./coredatastore.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(sqlLiteConnection);
        }






        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Blog>(entity =>
        //    //{
        //    //    entity.Property(e => e.Title).HasColumnType("varchar(128)");
        //    //    entity.Property(e => e.Url).HasColumnType("varchar(128)");
        //    //});

        //}

        public DbSet<Blog> Blogs { get; set; }

        //public DbSet<Post> Posts { get; set; }
    }
}