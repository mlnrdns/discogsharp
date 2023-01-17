namespace discogsharp.Domain;

public class Price
{
    public Currency Currency { get; set; }
    public string? Formatted { get; set; }
    public float Value { get; set; }
}
