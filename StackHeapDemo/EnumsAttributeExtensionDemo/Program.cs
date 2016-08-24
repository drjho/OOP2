using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace EnumsAttributeExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDemo();
        }

        [Author("JH", GroupName = Group.Squid)]
        static void StringDemo()
        {
            var str = "sluta!";
            Console.WriteLine(str.Shout());
        }

    }
}
