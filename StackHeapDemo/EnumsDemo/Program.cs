using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintUser("Bo", UserLevel.Student);
            PrintUser("Bo", UserLevel.Teacher);
        }

        static void PrintUser(string name, UserLevel userlevel)
        {
            Console.WriteLine($"Name:{name} Level:{(int)userlevel}");
        }
    }

    // När man använder entity-framworks (mot databas) så blir det en primärnyckel av int-arna.
    [Flags] // När man har flags måste man använda binära värden så att en user kan ha flera tillhörighet!!!
    enum UserLevel
    {
        Student = 0,
        Teacher = 2,
        Admin = 4
    }
}
