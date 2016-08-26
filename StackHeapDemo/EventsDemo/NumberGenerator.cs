using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    public class NumberGenerator
    {
        public delegate void EventHandler(object sender, EvenEventArgs e);

        public event EventHandler EvenNumberEvent;

        Random random = new Random();

        public void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                int randNum = random.Next();
                if (randNum % 2 == 0)
                {
                    EvenNumberEvent?.Invoke(this, new EvenEventArgs(randNum));
                }
            }
        }
    }

    public class EvenEventArgs : EventArgs
    {
        public EvenEventArgs(int i)
        {
            number = i;
        }

        public int number { get; private set; }
    }

}
