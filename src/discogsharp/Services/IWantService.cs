using discogsharp.Domain;

namespace discogsharp.Services;

public interface IWantService
{
    Task<WantedItem> AddReleaseAsync(string username, int releaseId, CancellationToken cancellationToken = default);

    Task<IEnumerable<PaginatedResponse<WantedItem>>> GetAllAsync(string username, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<WantedItem>> GetAsync(string username, int page = 1, int perPage = 100, CancellationToken cancellationToken = default);
    Task<WantedItem> UpdateReleaseAsync(string username, int releaseId, string notes, int rating, CancellationToken cancellationToken = default);
    Task<NoContent> DeleteReleaseAsync(string username, int releaseId, CancellationToken cancellationToken = default);
}
