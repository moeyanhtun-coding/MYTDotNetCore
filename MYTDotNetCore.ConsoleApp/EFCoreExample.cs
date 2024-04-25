using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYTDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();

        public void Run()
        {
            //Read();
            //Edit(2);
            //Edit(14);
            //Create("this is new title","this is new Author", "this is new Content");
            Update(14, "this is title", "this is author", "this is Content");
        }
        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogDto blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("____________________");
            }
        }
        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("____________________");
        }
        public void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

             db.Blogs.Add(item);
           int result = db.SaveChanges();
            string message = result > 0 ? "Creating Success" : "Creating Fail";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {

            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Success" : "Updating Fail";
            Console.WriteLine(message);

        }

    }
}
