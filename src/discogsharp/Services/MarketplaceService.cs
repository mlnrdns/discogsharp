using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services;

public class MarketplaceService : IMarketplaceService
{
    private readonly Connection connection;

    public MarketplaceService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<NoContent> AddListingAsync(ListingToAddOrUpdate listingToAddOrUpdate, CancellationToken cancellationToken = default)
        => await this.connection.SendRequestAsync<NoContent>(
            HttpMethod.Post,
            "marketplace/listings",
            new Dictionary<string, string>(listingToAddOrUpdate.AsDictionary()),
            cancellationToken);

    public async Task<NoContent> DeleteListingAsync(long id, CancellationToken cancellationToken = default)
        => await this.connection.SendRequestAsync<NoContent>(HttpMethod.Delete, $"marketplace/listings/{id}", cancellationToken);

    public async Task<NoContent> EditListingAsync(long id, ListingToAddOrUpdate listingToAddOrUpdate, CancellationToken cancellationToken = default)
            => await this.connection.SendRequestAsync<NoContent>(
            HttpMethod.Post,
            $"marketplace/listings/{id}",
            new Dictionary<string, string>(listingToAddOrUpdate.AsDictionary()),
            cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<ListingForInventory>>> GetAllInventoryForUser(string username, CancellationToken cancellationToken = default)
            => await connection.SendPagedRequestAsync<ListingForInventory>(HttpMethod.Get, $"users/{username}/inventory", cancellationToken);

    public async Task<PaginatedResponse<ListingForInventory>> GetInventoryForUser(
        string username,
        long page = Constants.DefaultPage,
        long perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await connection.SendPagedRequestAsync<ListingForInventory>(HttpMethod.Get, $"users/{username}/inventory", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{page}",
            [Constants.PerPageQueryParameterName] = $"{perPage}"
        }, cancellationToken);

    public async Task<Listing> GetListing(long id, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<Listing>(
        HttpMethod.Get, $"marketplace/listings/{id}", cancellationToken);
}
