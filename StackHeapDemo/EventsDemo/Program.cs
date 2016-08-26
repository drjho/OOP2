using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numGen = new NumberGenerator();
            numGen.EvenNumberEvent += OnEvenNumberEvent;
            
            numGen.Start();
        }

        static void OnEvenNumberEvent(object sender, EvenEventArgs e)
        {
            Console.WriteLine("Jämt tal: " + e.number);
        }
    }
}
