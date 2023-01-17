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
}
