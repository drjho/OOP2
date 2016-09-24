using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Threading;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {

        static string link1 = "http://www.google.com";
        static string link2 = "http://www.dn.se";
        static string link3 = "http://www.yahoo.com";

        HttpClient httpClient = new HttpClient();
        WebClient webClient = new WebClient();

        Uri uri1 = new Uri(link1);
        Uri uri2 = new Uri(link2);
        Uri uri3 = new Uri(link3);

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Waiting for command...";
        }

        /// <summary>
        /// Load a single page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "WebClient loading " + uri3.AbsoluteUri;

            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler((se, ev) =>
               { label1.Text = uri3.AbsoluteUri + " Done!"; });
            webClient.DownloadStringAsync(uri3);
        }

        /// <summary>
        /// I think this load pages in parallell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "HttpClient loading " + uri3.AbsoluteUri;

            await httpClient.GetStringAsync(uri3);

            label1.Text = uri3.AbsoluteUri + " Done!";
        }

        /// <summary>
        /// Seems not to load pages in parallell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "1by1 loading " + uri1.AbsoluteUri;
            await httpClient.GetStringAsync(uri1);
            label1.Text += " done\n " + uri2.AbsoluteUri;
            await httpClient.GetStringAsync(uri2);
            label1.Text += " done\n " + uri3.AbsoluteUri;
            await httpClient.GetStringAsync(uri3);
            label1.Text += " Done!";

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            try
            {
                var task1 = httpClient.GetStringAsync(uri1);
                var task2 = httpClient.GetStringAsync(uri2);
                var task3 = httpClient.GetStringAsync(uri3);

                var results = await Task.WhenAll(task1, task2, task3);

                label1.Text = "Loading " + uri1.AbsoluteUri + uri2.AbsoluteUri + uri3.AbsoluteUri + " all done!";

            }
            catch (Exception)
            {

                label1.Text = "Could not download HTML...";
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            try
            {
                //var t1 = httpClient.GetStringAsync(uri1);
                //var t2 = httpClient.GetStringAsync(uri2);
                //var t3 = httpClient.GetStringAsync(uri3);

                //List<Task<string>> tasks = new List<Task<string>>() { t1, t2, t3 };

                //while (tasks.Count > 0)
                //{
                //    Task<string> finishedTask = await Task.WhenAny(tasks);
                //    tasks.Remove(finishedTask);
                //    if (finishedTask.Equals(t1))
                //        label1.Text += uri1.AbsoluteUri;
                //    else if (finishedTask.Equals(t2))
                //        label1.Text += uri2.AbsoluteUri;
                //    else if (finishedTask.Equals(t3))
                //        label1.Text += uri3.AbsoluteUri;
                //    label1.Text += " done \n";
                //}

                // should add async?
                //GetStringAsync(uri1);
                //GetStringAsync(uri2);
                //GetStringAsync(uri3);


                await Task.WhenAll(GetStringAsync(uri1), GetStringAsync(uri2), GetStringAsync(uri3));
                label1.Text += "Done!";


                // no async required from here on...
                //Task.Factory.StartNew(() => GetStringAsync(uri1));
                //Task.Factory.StartNew(() => GetStringAsync(uri2));
                //Task.Factory.StartNew(() => GetStringAsync(uri3));

            }

            catch (Exception)
            {

                label1.Text = "Could not download HTML...";
            }
        }

        async Task GetStringAsync(Uri uri)
        {
            await httpClient.GetStringAsync(uri);
            label1.Text += uri.AbsoluteUri + "\n";
        }
    }
}
