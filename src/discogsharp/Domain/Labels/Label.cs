namespace discogsharp.Domain;

public class Label
{
    public string Name { get; set; }
    public string Profile { get; set; }
    public string ReleasesUrl { get; set; }
    public string Uri { get; set; }
    public DataQuality DataQuality { get; set; }
    public string ContactInfo { get; set; }
    public List<Sublabel> Sublabels { get; set; }
    public List<string> Urls { get; set; }
    public List<Image> Images { get; set; }
}
