using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambdaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Större än 5:");
            ProcessNumbers2(IsLargerThanFive);
            Console.WriteLine();
            Console.WriteLine("Mindre än 2:");
            ProcessNumbers2((id) => id < 2);
        }

        [Obsolete("This is used by ProcessNumbers which also is depracted.")]
        delegate bool funcOneInt(int i);

        static bool IsLargerThanFive(int i)
        {
            return i > 5;
        }
        
        static void ProcessNumbers2(Func<int, bool> f)
        {
            for (int i = 0; i < 10; i++)
            {
                if (f(i))
                {
                    Console.WriteLine("Träff: " + i);
                }
            }
        }

        [Obsolete("Use {ProcessNumbers2} instead of this...")]
        static void ProcessNumbers(funcOneInt f)
        {
            for (int i = 0; i < 10; i++)
            {
                if (f(i))
                {
                    Console.WriteLine("Träff: " + i);
                }
            }
        }
    }
}
