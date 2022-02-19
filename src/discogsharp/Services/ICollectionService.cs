using discogsharp.Domain;

namespace discogsharp.Services
{
    public interface ICollectionService
    {
        Task<FolderList> GetFolderListAsync(string username, CancellationToken cancellationToken = default);
        Task<AddFolderResponse> AddFolderAsync(string username, string folder, CancellationToken cancellationToken = default);
        Task<Folder> GetFolderAsync(string username, int id, CancellationToken cancellationToken = default);
        Task<AddFolderResponse> RenameFolderAsync(string username, int id, string newName, CancellationToken cancellationToken = default);
        Task<Folder> DeleteFolderAsync(string username, int id, CancellationToken cancellationToken = default);
    }
}