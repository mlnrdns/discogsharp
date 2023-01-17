using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services
{
    public interface ICollectionService
    {
        Task<PostCollectionResponse> AddFolderAsync(string username, string folder, CancellationToken cancellationToken = default);

        Task<PostCollectionResponse> AddToFolderAsync(
                string username,
                int folderId,
                int releaseId,
                CancellationToken cancellationToken = default);

        Task<NoContent> ChangeRatingOfReleaseAsync(
                string username,
                int folderId,
                int releaseId,
                int instanceId,
                int rating,
                CancellationToken cancellationToken = default);

        Task<Folder> DeleteFolderAsync(string username, long id, CancellationToken cancellationToken = default);

        Task<NoContent> DeleteInstanceFromFolderAsync(
                string username,
                int folderId,
                int releaseId,
                int instanceId,
                CancellationToken cancellationToken = default);

        Task<PaginatedResponse<CollectionItem>> GetCollectionItemsByFolderAsync(string username,
                int folderId,
                int page = Constants.DefaultPage,
                int perPage = Constants.DefaultPerPage,
                CancellationToken cancellationToken = default);

        Task<PaginatedResponse<CollectionItem>> GetCollectionItemsByReleaseAsync(
                string username,
                int releaseId,
                int page = Constants.DefaultPage,
                int perPage = Constants.DefaultPerPage,
                CancellationToken cancellationToken = default);

        Task<CollectionValue> GetCollectionValueAsync(string username, CancellationToken cancellationToken = default);

        Task<FieldList> GetCustomFieldsAsync(string username, CancellationToken cancellationToken = default);

        Task<Folder> GetFolderAsync(string username, long id, CancellationToken cancellationToken = default);

        Task<FolderList> GetFolderListAsync(string username, CancellationToken cancellationToken = default);

        Task<NoContent> MoveReleaseToAnotherFolderAsync(
                string username,
                int sourceFolderId,
                int releaseId,
                int instanceId,
                int destinationFolderId,
                CancellationToken cancellationToken = default);

        Task<PostCollectionResponse> RenameFolderAsync(string username, long id, string newName, CancellationToken cancellationToken = default);
    }
}
