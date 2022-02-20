using Newtonsoft.Json;

namespace discogsharp.Domain;

public class FolderList
{
    [JsonProperty("folders")]
    private List<Folder>? Folders { get; set; }
}
