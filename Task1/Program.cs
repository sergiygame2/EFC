using System;
using ConsoleApp.SQLite;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("TESTING START:\n");
            using (var db = new BloggingContext())
            {
                
                //<CREATING DATA>  <!--EXECUTE THIS BLOCK ONLY ONCE BECAUSE AN ERROR WILL OCCUR DUE TO UNIQUE URLS FILTER--!>
                
                //Adding blogs
                db.Blogs.Add(new Blog { Url = "http://distedu.ukma.edu.ua/" , Name = "Distedu" });
                db.Blogs.Add(new Blog { Url = "https://docs.efproject.net/", Name = "EF Core" });
                db.Blogs.Add(new Blog { Url = "http://stackoverflow.com/", Name = "StackOverflow" });
                db.Blogs.Add(new Blog { Url = "http://google.com/", Name = "Google" });
                db.Blogs.Add(new Blog { Url = "https://habrahabr.ru/company/yandex/blog/" , Name="Habr/Yandex" });
                db.Blogs.Add(new Blog { Url = "https://tproger.ru/category/problems/" , Name="Tproger/problems" });
                db.Blogs.Add(new Blog { Url = "http://www.nplusone.com/en/" , Name="Science" });
                db.Blogs.Add(new Blog { Url = "wrongurltoupdate" , Name = "Habr" });
                db.Blogs.Add(new Blog { Url = "wrongurltodelete" , Name = "WTD" });
                //

                //Adding posts
                db.Posts.Add( new Post { BlogId = 2, Title = "EF Core actions", Content = "https://msdn.microsoft.com/en-us/data/jj592676.aspx" } );
                db.Posts.Add( new Post { BlogId = 2, Title = "EF Core Basic query", Content = "https://docs.efproject.net/en/latest/querying/basic.html" } );
                //
 
                //Saving data
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                //
                //<CREATING DATA/>  <!--EXECUTE THIS BLOCK ONLY ONCE BECAUSE AN ERROR WILL OCCUR DUE TO UNIQUE URLS FILTER--!>
                

                //Starting work with our data
                var blogsAmount = db.Blogs.Count();
                Console.WriteLine("\nAmount of blogs - {0}", blogsAmount);
                
                //Printing all blogs
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" -> {0} - {1} - {2}",blog.BlogId,blog.Name, blog.Url);
                }

                //Removing wrong blog
                var blogDel = db.Blogs.Single(b => b.Url == "wrongurltodelete");
                db.Remove(blogDel);
                //

                //Select a single blog entity and update it
                var sb = db.Blogs.Single(b => b.BlogId == 8);
                Console.WriteLine("\nSELECTED BLOG -> {0} - {1}",sb.BlogId, sb.Url);

                sb.Url = "https://habrahabr.ru/";
                Console.WriteLine("UPDATED SELECTED BLOG -> {0} - {1}",sb.BlogId, sb.Url);
                db.SaveChanges();
                //

                //Getting blogs with a special url
                var blogs = db.Blogs
                            .Where(b => b.Url.Contains(".net"))
                            .AsNoTracking()
                            .ToList();
                Console.WriteLine("\nAmount of blogs that contains '.net' - {0}", blogs.Count());
                //

                //using sql
                var sqlBlogs = db.Blogs
                                 .FromSql("SELECT * FROM Blogs WHERE Url='http://stackoverflow.com/' ")
                                 .AsNoTracking()
                                 .ToList();
                Console.WriteLine("\nAmount of blogs from sql query where url = 'http://stackoverflow.com/' - {0}", sqlBlogs.Count());                 
                //
                
                Console.WriteLine();
                //getting all blogs with posts
                var blogswp = db.Blogs
                            .Include(blog => blog.Posts)
                            .Where(blog => blog.Posts.Count() > 0)
                            .AsNoTracking()
                            .ToList();
                            
                Console.WriteLine("Amount of blogs with posts - {0}", blogswp.Count());

                foreach (var item in blogswp)
                {
                    Console.WriteLine("\nBlog -> {0} - {1}\nIt's posts:",item.BlogId, item.Url);
                    foreach (var post in item.Posts)
                    {
                        Console.WriteLine("Post {0} -> {1} - {2}",post.PostId,post.Title, post.Content);
                    }
                }
                //

                //searching for habarahabr blogs
                var searchTerm = "habrahabr";
                var sBlogs  = db.Blogs
                                .FromSql("SELECT * FROM Blogs")
                                .Where(b => b.Url.Contains($"{searchTerm}"))
                                .OrderByDescending(b => b.Name)
                                .ToList();
                Console.WriteLine("\nBlogs from habrahabr: ");
                foreach (var blog in sBlogs)
                {
                    Console.WriteLine("BlogId {0} -> {1} - {2}",blog.BlogId,blog.Name, blog.Url);
                }
                //

                // Display all Blogs from the database once more
                var query = from b in db.Blogs 
                            orderby b.Name 
                            select b; 

                Console.WriteLine("\nAll blogs in the database after some actions ordered by Name:"); 
                foreach (var item in query) 
                { 
                    Console.WriteLine("Blog {0} -> {1} - {2}",item.BlogId,item.Name, item.Url);
                } 

            }//using db
            Console.WriteLine("\nSUCCESS! END.");
        }//main

    }//class Program

}
