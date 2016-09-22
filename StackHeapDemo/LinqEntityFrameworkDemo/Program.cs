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
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }
                if (name.Equals("q"))
                    break;

                var books = db.Authors.GroupJoin(db.Books, a => a.Id, b => b.AuthorId,
                    (a, b) => new { Author = a, Titles = b.Select(bo => bo.Title) }).SingleOrDefault(a => a.Author.Name.Contains(name));

                if (books != null)
                {
                    Console.WriteLine($"{books.Author.Name}: {string.Join(", ", books.Titles)}");
                    AskToRemove(db, books.Author);
                }
                else
                {
                    Console.WriteLine("No such author.");
                }
            }
        }

        private static void AskToRemove(LibraryContext db, Author author)
        {
            Console.Write("Do you want to remove the author? [y,n]: ");
            var input = Console.ReadLine();

            if (input.Length < 2)
            {
                if (input.ToLowerInvariant().Equals("y"))
                {
                    db.Authors.Remove(author);
                    int rowCount = db.Database.ExecuteSqlCommand(
                        "DELETE FROM Books WHERE AuthorId = {0}", author.Id);
                    db.SaveChanges();
                    Console.WriteLine(author.Name + " removed and " + rowCount + " of books from db.");
                }
                else
                {
                    Console.WriteLine("Nothing is removed.");
                }
            }

        }
    }
}
