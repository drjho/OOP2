using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqXMLDemo.Library;
using System.Xml.Linq;
using System.IO;

namespace LoadXMLDemo
{
    class Program
    {
        static XElement xml;
        static XDocument xDoc;

        static void Main(string[] args)
        {
            var path = Path.Combine(@"C:\Users\m97_j\Source\Repos\OOP2\StackHeapDemo\LinqXMLDemo\bin\Debug", "authors.xml");
            Console.WriteLine(path);
            xDoc = XDocument.Load(Path.GetFullPath(path));
            Console.WriteLine("XDoc read");
            xml = XElement.Load(File.OpenText(Path.GetFullPath(path)));
            Console.WriteLine("Xml read");

            GetAuthorsBook();
        }

        static void GetBooksOfAuthorFromDoc(string name)
        {
            var titles = xDoc.Descendants("author").SingleOrDefault(a => a.Attribute("name").Value.Contains(name))?.Elements("book").Select(b => b.Attribute("title").Value);
            if (titles == null)
            {
                Console.WriteLine("No such author.");
                return;
            }
            Console.WriteLine(" " + string.Join(", ", titles));
        }

        static void GetBooksOfAuthor(string name)
        {
            
            var books = xml.Descendants("author").SingleOrDefault(a => a.Attribute("name").Value.Contains(name))?.Elements("book").Select(b => b.Attribute("title").Value);
            if (books == null)
            {
                Console.WriteLine("No such author.");
                return;
            }
            foreach (var item in books)
            {
                Console.WriteLine(" " + item);
            }
        }

        static void GetAuthorsBook()
        {
            while (true)
            {
                Console.Write("Enter author's name: ");
                var name = Console.ReadLine();
                if (name.Equals("q"))
                    break;
                Console.WriteLine("--Results from XElement--:");
                GetBooksOfAuthor(name);
                Console.WriteLine("--Results from XDocument--:");
                GetBooksOfAuthorFromDoc(name);
            }
        }
    }
}
