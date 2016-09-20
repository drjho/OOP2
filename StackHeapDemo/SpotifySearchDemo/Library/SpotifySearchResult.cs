using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySearchDemo.Library
{
    public class SpotifySearchResult
    {
        public AlbumsContainer albums { get; set; }

        [JsonProperty(PropertyName = "artists")]
        public ArtistContainer Container { get; set; }
    }

    public class AlbumsContainer
    {
        public List<Album> items { get; set; }
    }

    public class Album
    {
        public string name { get; set; }
    }

    public class ArtistContainer
    {
        [JsonProperty(PropertyName = "items")]
        public List<Artist> Artists { get; set; }
    }

    public class Artist
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
