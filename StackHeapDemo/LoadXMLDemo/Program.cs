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
        static XDocument xDoc;

        static void Main(string[] args)
        {
            var path = Path.Combine(@"C:\Users\m97_j\Source\Repos\OOP2\StackHeapDemo\LinqXMLDemo\bin\Debug", "authors.xml");
            xDoc = XDocument.Load(Path.GetFullPath(path));
            Console.WriteLine($"{path} read");

            GetAuthorsBook();
        }

        static void GetBooksOfAuthorFromDoc(string name)
        {
            
            var author = xDoc.Descendants("author").FirstOrDefault(a => a.Attribute("name").Value.Contains(name));
            var titles = author?.Elements("book").Select(b => b.Attribute("title").Value);
            if (titles == null)
            {
                Console.WriteLine("No such author.");
                return;
            }
            Console.WriteLine(author.Attribute("name").Value + ": " + string.Join(", ", titles));
            AskAndRemoveAuthor(author);
        }

        static void AskAndRemoveAuthor(XElement author)
        {
            
            Console.Write($"Do you want to remove {author.Attribute("name").Value} [y, n]");
            var key = Console.ReadKey();
            Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    author.Remove();
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("No change is made");
                    break;
                default:
                    break;
            }
            Console.WriteLine(xDoc);

        }

        static void GetAuthorsBook()
        {
            while (true)
            {
                Console.Write("Enter author's name: ");
                var name = Console.ReadLine();
                if (name.Equals("q"))
                    break;
                Console.WriteLine("--Results from XDocument--:");
                GetBooksOfAuthorFromDoc(name);
            }
        }
    }
}
