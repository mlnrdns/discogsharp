using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Track
    {
        public List<Artist> Artists { get; set; }
        public string Duration { get; set; }
        public List<Artist> ExtraArtists { get; set; }
        public string Position { get; set; }

        [JsonProperty("sub_tracks")]
        public List<Track> SubTracks { get; set; }

        public string Title { get; set; }

        [JsonProperty("type_")]
        public string Type { get; set; }
    }
}
