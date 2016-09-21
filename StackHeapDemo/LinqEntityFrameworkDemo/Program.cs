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
                SearchAuthor(db);

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

                var books = db.Authors.GroupJoin(db.Books, a => a.Id, b => b.AuthorId,
                    (a, b) => new { AuthorName = a.Name, Titles = b.Select(bo => bo.Title) }).SingleOrDefault(a => a.AuthorName.Contains(name));

                if (books != null)
                {
                    Console.WriteLine($"{books.AuthorName}: {string.Join(", ", books.Titles)}");
                }
                else
                {
                    Console.WriteLine("No such author.");
                }
            }
        }
    }
}
