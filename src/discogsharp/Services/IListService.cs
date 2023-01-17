using discogsharp.Domain;

namespace discogsharp.Services
{
    public interface IListService
    {
        Task<IEnumerable<PaginatedResponse<DiscogsListForUser>>> GetAllByUserAsync(string username, CancellationToken cancellationToken = default);

        Task<DiscogsList> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        Task<PaginatedResponse<DiscogsListForUser>> GetByUserAsync(string username, int page = 1, int perPage = 100, CancellationToken cancellationToken = default);
    }
}
