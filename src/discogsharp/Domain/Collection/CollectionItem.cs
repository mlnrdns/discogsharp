namespace discogsharp.Domain;

public class CollectionItem
{
    public int Id { get; set; }
    public int InstanceId { get; set; }
    public DateTime DateAdded { get; set; }
    public int FolderId { get; set; }
    public BasicInformation? BasicInformation { get; set; }
}