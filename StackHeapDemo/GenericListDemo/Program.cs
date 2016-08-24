using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var intList = new GenericList<int>();
            intList.Add(4);
            Console.WriteLine(intList.Count);
            intList.Add(5);
            Console.WriteLine(intList.Count);
            intList.Add(6);
            Console.WriteLine(intList.Count);


            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }

            intList[2] = 106;
            Console.WriteLine(intList[2]);

            Console.WriteLine("===============");
            

            var pList = new GenericList<Person>();
            var p1 = new Person("Bo", 13);

            pList.Add(new Person("Doe", 40));
            pList.Add(p1);
            pList.Add(new Person("Allan", 55));

            for (int i = 0; i < pList.Count; i++)
            {
                Console.WriteLine(pList[i].Name + " " +pList[i].Age);
            }

            pList.Remove(p1);
            Console.WriteLine($"count: {pList.Count}");
            foreach (var p in pList)
            {
                Console.WriteLine(p.Name + " " + p.Age);
            }
            Console.WriteLine("===============");


            var fList = new GenericList<float>();
            for (int i = 0; i < 20; i++)
            {
                fList.Add((float)Math.Sqrt(i));
            }

            Console.WriteLine($"flist count: {fList.Count}");


            foreach (var f in fList)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine();
            fList.RemoveAt(10);

            foreach (var f in fList)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine($"fList count: {fList.Count}");
            fList.Remove(10);
            Console.WriteLine($"after remove fList count: {fList.Count}");

            foreach (var f in fList)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine($"fList count: {fList.Count}");
            fList.Remove(3);
            Console.WriteLine($"after remove fList count: {fList.Count}");

            foreach (var f in fList)
            {
                Console.WriteLine(f);
            }
        }
    }

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
