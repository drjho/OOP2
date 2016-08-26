using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventsDemo;

namespace EventsGUIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Jämt tal:\n";
            var numGen = new NumberGenerator();
            numGen.EvenNumberEvent += OnEvenNumberEvent;

            numGen.Start();
            
        }

        void OnEvenNumberEvent(object sender, EvenEventArgs e)
        {
            label1.Text += e.number + "\n";
        }
    }
}
