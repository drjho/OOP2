using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqXMLDemo.Library;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LinqJsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteAuthorsToDisk();
            ReadAuthorsFromDisk();
        }

        private static void SearchAuthor(List<Author> authors)
        {
            while (true)
            {
                Console.Write("Input: ");
                var name = Console.ReadLine();
                if (name.Equals("q"))
                    break;

                var author = authors.SingleOrDefault(a => a.Name.Contains(name));
                if (author != null)
                {
                    Console.WriteLine($"{author.Name}: {string.Join(", ", author.Books.Select(b => b.Title))}");
                }
                else
                {
                    Console.WriteLine("No such author.");
                }
            }
        }

        private static void WriteAuthorsToDisk()
        {
            var authors = Author.GetExamples();

            var json = JsonConvert.SerializeObject(authors);

            Console.WriteLine(json);

            File.WriteAllText("author.json", json);

            dynamic d = JArray.Parse(json);

            Console.WriteLine(d);

            var str = "";

            foreach (var item in d)
            {
                str += item.Name + "\n";
                foreach (var b in item.Books)
                {
                    str += b.Title + ", ";
                }
                Console.WriteLine(str);
                str = "";
            }

            Console.WriteLine("----");
        }

        private static void ReadAuthorsFromDisk()
        {
            var json = File.ReadAllText("author.json");

            var authors = JsonConvert.DeserializeObject<List<Author>>(json);

            foreach (var item in authors)
            {
                Console.WriteLine(item.Name + ":");
                Console.WriteLine(string.Join(", ", item.Books.Select(b => b.Title)));
            }
            Console.WriteLine("----");

            SearchAuthor(authors);
        }
    }
}
