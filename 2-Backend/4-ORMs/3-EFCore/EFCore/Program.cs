using EFCore.Model;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new BloggingContext();
            context.Blogs.Add(new Blog { Url = "google.com" });

            var book = context.Books.SingleOrDefault(b => b.BookKey == 2);
            context.Entry(book).Reference(a => a.Author).Load();
            Console.WriteLine(book.Author.FirstName);

            var book2 = context.Books.Include(b => b.Author).SingleOrDefault(b => b.BookKey == 2);

            var blog = context.Blogs.SingleOrDefault(b => b.BlogId == 1);
            context.Entry(blog)
                .Collection(a => a.Posts)
                .Query()
                .Where(p => p.PostId > 5)
                .ToList();

            var book3 = context.Books
                .Include(b => b.Author)
                .AsSingleQuery()
                .SingleOrDefault(b => b.BookKey == 2);

            var blogs = context.Books.IgnoreQueryFilters().ToList();

            var post = new Post
            {
                PostId = 2,
                BlogId = 4,
                Content = "7mada"
            };
            context.Update(post);
            context.Entry(post).Property(p => p.BlogId).IsModified = false;

            var books = (from b in context.Books
                         join a in context.Authors
                         on b.AuthorId equals a.Id
                         select new { a, b }).ToList();

            using var transaction1 = context.Database.BeginTransaction();
            try
            {
                context.Blogs.Add(new Blog { Url = "google.com" });
                context.SaveChanges();
                context.Blogs.Add(new Blog { BlogId = 4, Url = "google.com" });
                context.SaveChanges();
                transaction1.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                transaction1.Rollback();
                throw;
            }

            using var transaction2 = context.Database.BeginTransaction();
            try
            {
                context.Blogs.Add(new Blog { Url = "google.com" });
                context.SaveChanges();
                transaction2.CreateSavepoint("AddFirstBlog");
                context.Blogs.Add(new Blog { Url = "google.com" });
                context.Blogs.Add(new Blog { BlogId = 4, Url = "google.com" });
                context.SaveChanges();
                transaction2.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                transaction2.RollbackToSavepoint("AddFirstBlog");
                transaction2.Commit();
            }
            //test

            context.SaveChanges();
        }

        public static void SeedData()
        {
            using var context = new BloggingContext();
            context.Database.EnsureCreated();
            var blog = context.Blogs.FirstOrDefault(b => b.Url == "google.com");

            if (blog is null)
            {
                context.Blogs.Add(new Blog { Url = "google.com" });
            }

            context.SaveChanges();
        }
    }
}