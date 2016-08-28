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

namespace AsyncDemo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load a single page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Reading...";
            await DownLoadPageAsync("http://www.dn.se");
            label1.Text = "Done";
        }

        /// <summary>
        /// I think this load pages in parallell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            List<string> urlList = GetUrlList();

            label2.Text = "Reading...";
            IEnumerable<Task> downloadTasksQuery = from url in urlList select DownLoadPageAsync(url);
            await Task.WhenAll(downloadTasksQuery);
            label2.Text = "Done";
        }

        /// <summary>
        /// Seems not to load pages in parallell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            List<string> urlList = GetUrlList();

            label3.Text = "Reading...";
            foreach (var url in urlList)
            {
                await DownLoadPageAsync(url);
            }
            label3.Text = "Done";
        }

        List<string> GetUrlList()
        {
            return new List<string>
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };
        }

        async Task DownLoadPageAsync(string url)
        {
            using (var client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
            }
            
        }

    }
}
