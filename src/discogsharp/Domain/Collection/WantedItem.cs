namespace discogsharp.Domain;

public class WantedItem
{
    public DateTime DateAdded { get; set; }
    public BasicInformationForWantedItem BasicInformation { get; set; }
    public string Notes { get; set; }
    public int Rating { get; set; }
}
