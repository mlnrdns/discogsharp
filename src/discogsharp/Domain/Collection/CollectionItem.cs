namespace discogsharp.Domain;

public class CollectionItem
{
    public BasicInformation? BasicInformation { get; set; }
    public DateTime DateAdded { get; set; }
    public int FolderId { get; set; }
    public long Id { get; set; }
    public int InstanceId { get; set; }
}
