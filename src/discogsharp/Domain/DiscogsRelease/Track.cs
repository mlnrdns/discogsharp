using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Track
    {
        public string Duration { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }

        [JsonProperty("type_")]
        public string Type { get; set; }

        public List<Artist> ExtraArtists { get; set; }
        public List<Artist> Artists { get; set; }

        [JsonProperty("sub_tracks")]
        public List<Track> SubTracks { get; set; }
    }
}