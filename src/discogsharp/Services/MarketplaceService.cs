using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;
using System.Text;

namespace discogsharp.Services;

public class MarketplaceService : IMarketplaceService
{
    private readonly Connection connection;

    public MarketplaceService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<NoContent> EditListingAsync(
        long id,
        ListingToAddOrUpdate listingToAddOrUpdate,
        CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<NoContent>(
            HttpMethod.Post,
            $"marketplace/listings/{id}",
            new StringContent(JsonConvert.SerializeObject(listingToAddOrUpdate), Encoding.UTF8, Constants.DefaultMediaType),
            cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<ListingForInventory>>> GetAllInventoryForUser(string username, CancellationToken cancellationToken = default)
            => await connection.SendPagedRequestAsync<ListingForInventory>(HttpMethod.Get, $"users/{username}/inventory", cancellationToken);

    public async Task<PaginatedResponse<ListingForInventory>> GetInventoryForUser(
        string username,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await connection.SendPagedRequestAsync<ListingForInventory>(HttpMethod.Get, $"users/{username}/inventory", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{page}",
            [Constants.PerPageQueryParameterName] = $"{perPage}"
        }, cancellationToken);

    public async Task<Listing> GetListing(long id, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<Listing>(
        HttpMethod.Get, $"marketplace/listings/{id}", cancellationToken);
}
