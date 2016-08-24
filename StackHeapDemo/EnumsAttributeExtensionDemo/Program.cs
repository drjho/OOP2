using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace EnumsAttributeExtensionDemo
{
    [Author("JH", GroupName = Group.Squid)]
    public class Program
    {
        static void Main(string[] args)
        {
            StringDemo();


            foreach (MethodInfo method in (typeof(Program)).GetMethods())
            {
                foreach (object attribute in method.GetCustomAttributes(true))
                {
                    if (attribute is AuthorAttribute)
                    {
                        Console.WriteLine(attribute.ToString());
                    }
                }
            }
  
        }

        [Author("JH", GroupName = Group.Squid)]
        public static void StringDemo()
        {
            var str = "sluta!";
            Console.WriteLine(str.Shout());
        }

        [Author("Foo")]
        public static void FooMethod()
        {

        }

        [Author("Bar")]
        public static void BarMetod()
        {

        }

    }

}
