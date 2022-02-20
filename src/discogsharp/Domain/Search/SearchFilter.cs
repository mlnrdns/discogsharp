using discogsharp.Utils;

namespace discogsharp.Domain;

public class SearchFilter
{
    public string Anv { get; set; }
    public string Artist { get; set; }
    public string Barcode { get; set; }
    public string Catno { get; set; }
    public string Contributor { get; set; }
    public string Country { get; set; }
    public string Credit { get; set; }
    public string Format { get; set; }
    public string Genre { get; set; }
    public string Label { get; set; }
    public string Page { get; set; } = $"{Constants.DefaultPage}";
    public string PerPage { get; set; } = $"{Constants.DefaultPerPage}";
    public string Query { get; set; }
    public string ReleaseTitle { get; set; }
    public string Style { get; set; }
    public string Submitter { get; set; }
    public string Title { get; set; }
    public string Track { get; set; }
    public ResourceType Type { get; set; }
    public string Year { get; set; }
}
