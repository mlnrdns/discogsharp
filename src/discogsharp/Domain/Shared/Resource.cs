namespace discogsharp.Domain;

public abstract class Resource
{
    public int Id { get; set; }
    public string ResourceUrl { get; set; } = null!;
}