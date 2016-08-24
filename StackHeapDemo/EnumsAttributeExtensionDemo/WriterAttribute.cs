using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsAttributeExtensionDemo
{
    enum Group
    {
        Tiger, Squid, Penguin, Mouse
    }

    [AttributeUsage(AttributeTargets.Method)]
    class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
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
    }
}