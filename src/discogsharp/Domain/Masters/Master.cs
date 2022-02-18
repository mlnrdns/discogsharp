using Newtonsoft.Json;

namespace discogsharp.Domain
{
    public class Master
    {
        public string Title { get; set; }
        public string VersionsUrl { get; set; }
        public string Uri { get; set; }
        public int MainRelease { get; set; }
        public string MainReleaseUrl { get; set; }
        public int Year { get; set; }
        public List<string> Styles { get; set; }
        public List<string> Genres { get; set; }
        public DataQuality DataQuality { get; set; }
        public List<Video> Videos { get; set; }
        public List<ArtistForRelease> Artists { get; set; }
        public List<Image> Images { get; set; }

        [JsonProperty("tracklist")]
        public List<Track> TrackList { get; set; }
    }
}