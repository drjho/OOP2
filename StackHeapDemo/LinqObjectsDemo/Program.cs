using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqObjectsDemo.Extensions;

namespace LinqObjectsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>()
            {
                new Person() { Name = "Bo", Age = 29, WorkPlaceID = 0 },
                new Person() { Name = "An", Age = 30, WorkPlaceID = 0 },
                new Person() { Name = "Mats", Age = 31, WorkPlaceID = 1 },
                new Person() { Name = "Per", Age = 32, WorkPlaceID = 1 },
                new Person() { Name = "Li", Age = 33, WorkPlaceID = 1 },

            };

            var workplaces = new List<Workplace>()
            {
                new Workplace() { WorkPlaceID = 0, CompanyName = "Ica" },
                new Workplace() { WorkPlaceID = 1, CompanyName = "Coop" }
            };

            var persOver30s = from p in persons
                              where p.Age > 30
                              orderby p.Name, p.Age
                              select p;

            persOver30s.Print(c => c.Name);
            Console.WriteLine("-----------------");

            var persWorkplaces = persons.Join(workplaces, p => p.WorkPlaceID, w => w.WorkPlaceID,
                (p, w) => new { Name = p.Name, CompanyName = w.CompanyName });

            persWorkplaces.Print(e => $"{e.Name} {e.CompanyName}");
            Console.WriteLine("-----------------");

            var placeCounts = workplaces.GroupJoin(persons, w => w.WorkPlaceID, p => p.WorkPlaceID,
                (w, p) => new { CompanyName = w.CompanyName, CompanyCount = p.Count() });

            placeCounts.Print(e => $"{e.CompanyName} {e.CompanyCount}");
            Console.WriteLine("-----------------");

            var placeWorkers = workplaces.GroupJoin(persons, w => w.WorkPlaceID, p => p.WorkPlaceID,
                (w, p) => new { CompanyName = w.CompanyName, Persons = p.Select( e => e.Name)});

            foreach (var item in placeWorkers)
            {
                Console.WriteLine(item.CompanyName);
                Console.WriteLine(string.Join(",", item.Persons));
            }
            Console.WriteLine("-----------------");

        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int WorkPlaceID { get; set; }
    }

    class Workplace
    {
        public string CompanyName { get; set; }
        public int WorkPlaceID { get; set; }
    }
}
