using Newtonsoft.Json;

namespace discogsharp.Domain;

public class Release : Resource
{
    public List<ArtistForRelease> Artists { get; set; }
    public List<Entity> Companies { get; set; }
    public int CountForSale { get; set; }
    public string Country { get; set; }
    public DataQuality DataQuality { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateChanged { get; set; }

    [JsonProperty("extraartists")]
    public List<ArtistForRelease> ExtraArtists { get; set; }

    public int FormatQuantity { get; set; }
    public List<Format> Formats { get; set; }
    public List<string> Genres { get; set; }
    public List<Identifier> Identifiers { get; set; }
    public List<Image> Images { get; set; }
    public List<Entity> Labels { get; set; }
    public float? LowestPrice { get; set; }
    public int MasterId { get; set; }
    public string MasterUrl { get; set; }
    public string Notes { get; set; }
    public string Released { get; set; }
    public string ReleaseFormatted { get; set; }
    public List<Entity> Series { get; set; }
    public string Status { get; set; }
    public List<string> Styles { get; set; }
    public string Thumb { get; set; }
    public string Title { get; set; }

    [JsonProperty("tracklist")]
    public List<Track> TrackList { get; set; }

    public string Uri { get; set; }
    public List<Video> Videos { get; set; }
    public int Year { get; set; }
}
