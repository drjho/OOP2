using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqXMLDemo.Library;
using System.Xml.Linq;

namespace LinqXMLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var authors = Author.GetExamples();

            var xml = new XDocument(
                new XElement("authors",
                    authors.Select(a => new XElement("author",
                    new XAttribute("name", a.Name),
                    a.Books.Select(b => new XElement("book", 
                        new XAttribute("title", b.Title),
                        new XAttribute("pageCount", b.PageCount))
                    ))
                ))
            );

            xml.Save("Authors.xml");
            Console.WriteLine("xml saved.");
        }
    }
}
