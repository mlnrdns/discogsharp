using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;
using System.Text;

namespace discogsharp.Services;

public class CollectionService : ICollectionService
{
    private readonly Connection connection;

    public CollectionService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<PostCollectionResponse> AddFolderAsync(string username, string folder, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<PostCollectionResponse>(
        HttpMethod.Post,
        $"users/{username}/collection/folders",
        new StringContent(JsonConvert.SerializeObject(new Folder { Name = folder }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<PostCollectionResponse> AddToFolderAsync(
        string username,
        int folderId,
        int releaseId,
        CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<PostCollectionResponse>(HttpMethod.Post,
        $"users/{username}/collection/folders/{folderId}/releases/{releaseId}",
        cancellationToken);

    public async Task<NoContent> ChangeRatingOfReleaseAsync(
        string username,
        int folderId,
        int releaseId,
        int instanceId,
        int rating,
        CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<NoContent>(HttpMethod.Post,
        $"users/{username}/collection/folders/{folderId}/releases/{releaseId}/instances/{instanceId}",
        new StringContent(JsonConvert.SerializeObject(new ReleaseRatingInFolder { Rating = rating }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<Folder> DeleteFolderAsync(string username, long id, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<Folder>(HttpMethod.Delete,
        $"users/{username}/collection/folders/{id}",
        cancellationToken);

    public async Task<NoContent> DeleteInstanceFromFolderAsync(string username, int folderId, int releaseId, int instanceId,
        CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<NoContent>(HttpMethod.Delete,
        $"users/{username}/collection/folders/{folderId}/releases/{releaseId}/instances/{instanceId}",
        cancellationToken);

    public async Task<PaginatedResponse<CollectionItem>> GetCollectionItemsByFolderAsync(
        string username,
        int folderId,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await this.connection.SendPagedRequestAsync<CollectionItem>(HttpMethod.Get,
        $"users/{username}/collection/folders/{folderId}/releases",
        new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{page}",
            [Constants.PerPageQueryParameterName] = $"{perPage}"
        },
        cancellationToken);

    public async Task<PaginatedResponse<CollectionItem>> GetCollectionItemsByReleaseAsync(
        string username,
        int releaseId,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await this.connection.SendPagedRequestAsync<CollectionItem>(HttpMethod.Get,
        $"users/{username}/collection/releases/{releaseId}",
        new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{page}",
            [Constants.PerPageQueryParameterName] = $"{perPage}"
        },
        cancellationToken);

    public async Task<CollectionValue> GetCollectionValueAsync(string username, CancellationToken cancellationToken = default)
    => await this.connection.SendRequestAsync<CollectionValue>(HttpMethod.Get, $"users/{username}/collection/value", cancellationToken);

    public async Task<FieldList> GetCustomFieldsAsync(string username, CancellationToken cancellationToken = default)
    => await this.connection.SendRequestAsync<FieldList>(HttpMethod.Get, $"users/{username}/collection/fields", cancellationToken);

    public async Task<Folder> GetFolderAsync(string username, long id, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<Folder>(HttpMethod.Get,
        $"users/{username}/collection/folders/{id}",
        cancellationToken);

    public async Task<FolderList> GetFolderListAsync(string username, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<FolderList>(HttpMethod.Get,
                                                $"users/{username}/collection/folders",
        cancellationToken);

    public async Task<NoContent> MoveReleaseToAnotherFolderAsync(
        string username,
        int sourceFolderId,
        int releaseId,
        int instanceId,
        int destinationFolderId,
        CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<NoContent>(HttpMethod.Post,
        $"users/{username}/collection/folders/{sourceFolderId}/releases/{releaseId}/instances/{instanceId}",
        new StringContent(JsonConvert.SerializeObject(new ReleaseRatingInFolder { FolderId = destinationFolderId }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<PostCollectionResponse> RenameFolderAsync(string username, long id, string newName, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<PostCollectionResponse>(
            HttpMethod.Post,
        $"users/{username}/collection/folders/{id}",
        new StringContent(JsonConvert.SerializeObject(new Folder { Name = newName }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);
}
