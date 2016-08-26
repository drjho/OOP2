using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsAttributeExtensionDemo
{
    enum Group
    {
        NoGroup, Tiger, Squid, Penguin, Mouse
    }

    [AttributeUsage(AttributeTargets.All)]
    class WrittenByAttribute : Attribute
    {
        public WrittenByAttribute(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "Author : " + Name + " GroupName : " + GroupName.ToString() ;
        }

        public string Name { get; set; }

        public Group GroupName { get; set; }
    }
}

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Shout(this string value)
        {
            return value.ToUpperInvariant();
        }

        public static string Truncate(this string value, int i)
        {
            return value.Substring(0, i) + "...";
        }
    }
}