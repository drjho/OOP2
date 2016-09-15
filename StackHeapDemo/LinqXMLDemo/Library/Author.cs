using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXMLDemo.Library
{
    public class Author
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public static List<Author> GetExamples()
        {
            return new List<Author>
            {
                new Author
                {
                    Name = "Douglas Adams",
                    Books = new List<Book>
                    {
                        new Book { Title = "Hitchhikers Guide To The Galaxy", PageCount = 300 },
                        new Book { Title = "So Long And Thanks For All The Fish", PageCount = 200 }
                    }
                 },
                new Author
                {
                    Name = "Hunter S. Thompson",
                    Books = new List<Book>
                    {
                        new Book { Title = "Fear And Loathing In Las Vegas", PageCount = 250 }
                    }
                }
            };
        } 
           
    }

    
}
