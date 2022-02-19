using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace discogsharp.Domain;

public class FolderList
{
    [JsonProperty("folders")]
    List<Folder>? Folders { get; set; }
}