using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqObjectsDemo.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }

        public static void Print<T>(this IEnumerable<T> enumerable, Func<T, object> predicate)
        {
            foreach (var item in enumerable)
                Console.WriteLine(predicate(item));
        }
    }
}
