using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;

namespace discogsharp.Services;

public class WantService : IWantService
{
    private readonly Connection connection;

    public WantService(Connection connection)
    {
        this.connection = connection;
    }

    public async Task<WantedItem> AddReleaseAsync(string username, int releaseId, CancellationToken cancellationToken = default)
    => await this.connection.SendRequestAsync<WantedItem>(HttpMethod.Put, $"users/{username}/wants/{releaseId}", cancellationToken);

    public async Task<NoContent> DeleteReleaseAsync(string username, int releaseId, CancellationToken cancellationToken = default)
    => await this.connection.SendRequestAsync<NoContent>(HttpMethod.Delete, $"users/{username}/wants/{releaseId}", cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<WantedItem>>> GetAllAsync(string username, CancellationToken cancellationToken = default)
    => await this.connection.SendPagedRequestAsync<WantedItem>(HttpMethod.Get,
        $"users/{username}/wants",
        cancellationToken);

    public async Task<PaginatedResponse<WantedItem>> GetAsync(
            string username,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await this.connection.SendPagedRequestAsync<WantedItem>(HttpMethod.Get,
        $"users/{username}/wants", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{Constants.DefaultPage}",
            [Constants.PerPageQueryParameterName] = $"{Constants.DefaultPerPage}"
        }, cancellationToken);

    public async Task<WantedItem> UpdateReleaseAsync(string username, int releaseId, string notes, int rating, CancellationToken cancellationToken = default) => await this.connection.SendRequestAsync<WantedItem>(HttpMethod.Post, $"users/{username}/wants/{releaseId}",
        new StringContent(JsonConvert.SerializeObject(new WantedItem { Rating = rating, Notes = notes })), cancellationToken);
}
