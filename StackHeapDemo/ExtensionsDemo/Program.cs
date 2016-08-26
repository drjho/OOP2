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
        }
    }
}
