using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace EnumsAttributeExtensionDemo
{
    [WrittenBy("JH", GroupName = Group.Squid)]
    public class Program
    {
        static void Main(string[] args)
        {
            StringDemo();


            foreach (MethodInfo method in (typeof(Program)).GetMethods())
            {
                foreach (object attribute in method.GetCustomAttributes(true))
                {
                    if (attribute is WrittenByAttribute)
                    {
                        var attr = (WrittenByAttribute)attribute;
                        Console.WriteLine(method.Name + " written by " + attr.Name + " in group " + attr.GroupName);
                    }
                }
            }
  
        }

        [WrittenBy("JH", GroupName = Group.Squid)]
        public static void StringDemo()
        {
            var str = "sluta!";
            Console.WriteLine(str.Shout());
        }

        [WrittenBy("Foo")]
        public static void FooMethod()
        {

        }

        [WrittenBy("Bar")]
        public static void BarMetod()
        {

        }

    }

}
