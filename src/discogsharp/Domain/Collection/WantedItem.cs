namespace discogsharp.Domain;

public class WantedItem
{
    public BasicInformationForWantedItem BasicInformation { get; set; }
    public DateTime DateAdded { get; set; }
    public string Notes { get; set; }
    public int Rating { get; set; }
}
