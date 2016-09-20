using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifySearchDemo.Library;

namespace SpotifySearchDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var searchTerm = textBox1.Text;

            if (searchTerm.Length < 4)
            {
                toolStripStatusLabel1.Text = "Not searching, you need at least 4 letters...";
                return;
            }

            toolStripStatusLabel1.Text = "Searching: " + searchTerm;

            var client = new HttpClient();
            var url = $"https://api.spotify.com/v1/search?q={searchTerm}&type=album,artist";

            var json = await client.GetStringAsync(url);
            var searchResult = JsonConvert.DeserializeObject<SpotifySearchResult>(json);

            label2.Text = "";
            foreach (var artist in searchResult.Container.Artists)
            {
                label2.Text += artist.Name + "\n";
            }

            label3.Text = "";
            foreach (var album in searchResult.albums.items)
            {
                label3.Text += album.name + "\n";
            }
        }

        
    }
}
