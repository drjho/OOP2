using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHeapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Bo", 30);
            CelebrateBirthday(p1);
            Console.WriteLine(p1.Age);
            p1 = null;

            int i = 10;
            Increase(i);
            Console.WriteLine(i);

        }

        static void CelebrateBirthday(Person person)
        {
            person.Age++;
        }

        static void Increase(int value)
        {
            value++;
        }
    }

    // Ref-type
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
