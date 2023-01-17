namespace discogsharp.Domain;

public class BasicInformationForWantedItem : BasicInformation
{
    public string CoverImage { get; set; }
    public List<string> Genres { get; set; }
    public int? MasterId { get; set; }
    public string MasterUrl { get; set; }
    public List<string> Styles { get; set; }
}
