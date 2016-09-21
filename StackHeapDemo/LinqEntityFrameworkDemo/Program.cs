using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqEntityFrameworkDemo.Entities;
using System.Data.Entity;

namespace LinqEntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LibraryContext())
            {
                

                //SearchAuthor(db);

                //var authors = db.Authors.Select(a => a.Name);
                //foreach (var item in authors)
                //{
                //    Console.WriteLine(item);
                //}

                //var books = db.Books.Select(b => b.Title);

                //foreach (var item in books)
                //{
                //    Console.WriteLine(item);
                //}
                //var authorBooks = db.Authors.Include(a => a.Books).Where(a => a.Id == 1);
            }
        }

        private static void SearchAuthor(LibraryContext db)
        {
            while (true)
            {
                Console.Write("Input: ");
                var name = Console.ReadLine();
                if (name.Equals("q"))
                    break;

                var author = db.Authors.Include(a => a.).SingleOrDefault(a => a.Name.Contains(name));

                //author = db.Authors.SingleOrDefault(a => a.Name.Contains(name));

                //if (author != null)
                //{
                //    Console.WriteLine($"{author.Name}: {string.Join(", ", author.Books.Select(b => b.Title))}");
                //}
                //else
                //{
                //    Console.WriteLine("No such author.");
                //}
            }
        }
    }
}
