namespace discogsharp.Domain;

public class ReleaseForArtist
{
    public string Thumb { get; set; }
    public string Artist { get; set; }
    public string Title { get; set; }
    public int MainRelease { get; set; }
    public string Role { get; set; }
    public int Year { get; set; }
    public ResourceType Type { get; set; }
}