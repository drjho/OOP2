using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionsDemo.Extensions;

namespace ExtensionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random.Percentage(50));
            }

            var o = new
            {
                Id = 1,
                Name = "Pontus",
                Created = DateTime.Now
            };

            Console.WriteLine(o.Name);

            var a = new
            {
                Age = random.Next(0, 100 + 1),
                Name = "Bo"
            };

            Console.WriteLine(a.ToString());

        }
    }
}
