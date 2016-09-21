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
                var authors = db.Authors.Select(a => a.Name);

                foreach (var item in authors)
                {
                    Console.WriteLine(item);
                }

                var books = db.Books.Select(b => b.Title);

                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }
                var authorBooks = db.Authors.Include(a => a.Books).Where(a => a.Id == 1);
            }
        }
    }
}
