using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services
{
    public interface IMarketplaceService
    {
        Task<PaginatedResponse<ListingForInventory>> GetInventoryForUser(string username, int page = Constants.DefaultPage, int perPage = Constants.DefaultPerPage, CancellationToken cancellationToken = default);
        Task<IEnumerable<PaginatedResponse<ListingForInventory>>> GetAllInventoryForUser(string username, CancellationToken cancellationToken = default);
    }
}
