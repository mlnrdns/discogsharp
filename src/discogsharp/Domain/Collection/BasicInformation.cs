namespace discogsharp.Domain;

public class BasicInformation : Resource
{
    public List<ArtistForRelease>? Artists { get; set; }
    public string? CoverImage { get; set; }
    public List<Format>? Formats { get; set; }
    public List<Entity>? Labels { get; set; }
    public string? Thumb { get; set; }
    public string? Title { get; set; }
    public int? Year { get; set; }
}
