namespace discogsharp.Domain;

public class BasicInformation : Resource
{
    public string? Thumb { get; set; }
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public int? Year { get; set; }
    public List<Entity>? Labels { get; set; }
    public List<Entity>? Formats { get; set; }
    public List<ArtistForRelease>? Artists { get; set; }
}
