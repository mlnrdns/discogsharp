namespace discogsharp.Domain;

public class Label
{
    public string ContactInfo { get; set; }
    public DataQuality DataQuality { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public string Profile { get; set; }
    public string ReleasesUrl { get; set; }
    public List<Sublabel> Sublabels { get; set; }
    public string Uri { get; set; }
    public List<string> Urls { get; set; }
}
