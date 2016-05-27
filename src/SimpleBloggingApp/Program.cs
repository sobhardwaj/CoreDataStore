using System;

namespace SimpleBloggingApp
{

    //https://github.com/natemcmaster/docker-ef-talk

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();

                db.Blogs.Add(new Blog
                {
                    Title = "VS Code Tips and Tricks",
                    Url = "http://myblog.com"
                });

           
                db.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine("{0} - {1}", blog.Title, blog.Url);
                }






                //var blogs = db.Blogs.ToList();

                //foreach (var blog in blogs)
                //{
                //  Console.WriteLine($"Blog: {blog.Title}");
                //}
            }
        }
    }
}
