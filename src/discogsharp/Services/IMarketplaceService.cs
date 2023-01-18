using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services
{
    public interface IMarketplaceService
    {
        Task<NoContent> AddListingAsync(ListingToAddOrUpdate listingToAddOrUpdate, CancellationToken cancellationToken = default);

        Task<NoContent> DeleteListingAsync(long id, CancellationToken cancellationToken = default);

        Task<NoContent> EditListingAsync(long id, ListingToAddOrUpdate listingToAddOrUpdate, CancellationToken cancellationToken = default);

        Task<IEnumerable<PaginatedResponse<ListingForInventory>>> GetAllInventoryForUser(string username, CancellationToken cancellationToken = default);

        Task<PaginatedResponse<ListingForInventory>> GetInventoryForUser(string username, long page = Constants.DefaultPage, long perPage = Constants.DefaultPerPage, CancellationToken cancellationToken = default);

        Task<Listing> GetListing(long id, CancellationToken cancellationToken = default);
    }
}
