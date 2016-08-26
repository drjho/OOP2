using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsDemo.Extensions
{
    public static class RandomExtensions
    {
        public static bool Percentage(this Random random, int percentage)
        {
            return random.Next(1, 100 + 1) < percentage;
        }
    }
}
