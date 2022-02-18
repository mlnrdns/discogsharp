namespace discogsharp.Domain;

public class Pagination
{
    public int Page { get; set; }
    public int Pages { get; set; }
    public int Items { get; set; }
    public int PerPage { get; set; }
    public PaginationUrls Urls { get; set; } = null!;
}