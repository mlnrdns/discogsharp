using discogsharp.Domain;

namespace discogsharp.Services;

public class MarketplaceService
{
    private readonly Connection connection;

    public MarketplaceService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<IEnumerable<PaginatedResponse<ListingForInventory>>> GetListingsAsync(string username, CancellationToken cancellationToken = default) => await connection.SendPagedRequestAsync<ListingForInventory>(HttpMethod.Get,
        $"users/{username}/inventory",
        cancellationToken);
}