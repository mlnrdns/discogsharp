namespace discogsharp.Domain;

public class PaginatedResponse<T> : PaginatedResponse
{
    public List<T> Items { get; set; } = null!;
}

public class PaginatedResponse
{
    public Pagination Pagination { get; set; } = null!;
}
