using System.Text;
using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;

namespace discogsharp.Services;
public class CollectionService : ICollectionService
{
    private readonly Connection connection;
    public CollectionService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<FolderList> GetFolderListAsync(string username, CancellationToken cancellationToken = default) => await this.connection.SendRequest<FolderList>(HttpMethod.Get,
        $"users/{username}/collection/folders",
        cancellationToken);

    public async Task<AddFolderResponse> AddFolderAsync(string username, string folder, CancellationToken cancellationToken = default) => await this.connection.SendRequest<AddFolderResponse>(
        HttpMethod.Post,
        $"users/{username}/collection/folders",
        new StringContent(JsonConvert.SerializeObject(new Folder { Name = folder }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<Folder> GetFolderAsync(string username, int id, CancellationToken cancellationToken = default) => await this.connection.SendRequest<Folder>(HttpMethod.Get,
        $"users/{username}/collection/folders/{id}",
        cancellationToken);

    public async Task<AddFolderResponse> RenameFolderAsync(string username, int id, string newName, CancellationToken cancellationToken = default) => await this.connection.SendRequest<AddFolderResponse>(
        HttpMethod.Post,
        $"users/{username}/collection/folders/{id}",
        new StringContent(JsonConvert.SerializeObject(new Folder { Name = newName }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<Folder> DeleteFolderAsync(string username, int id, CancellationToken cancellationToken = default) => await this.connection.SendRequest<Folder>(HttpMethod.Delete,
        $"users/{username}/collection/folders/{id}",
        cancellationToken);


}
