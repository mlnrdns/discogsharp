using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;
using System.Text;

namespace discogsharp.Services;

public class DatabaseService : IDatabaseService
{
    private readonly Connection connection;

    public DatabaseService(Connection connection)
    {
        this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public async Task<ReleaseRatingByUser> AddOrUpdateReleaseRatingByUserAsync(long id, string username, int rating, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<ReleaseRatingByUser>(
        HttpMethod.Put,
        $"releases/{id}/rating/{username}",
        new StringContent(JsonConvert.SerializeObject(new ReleaseRatingByUser { Rating = rating }), Encoding.UTF8, Constants.DefaultMediaType),
        cancellationToken);

    public async Task<NoContent> DeleteReleaseRatingByUserAsync(long id, string username, CancellationToken cancellationToken = default)
    => await connection.SendRequestAsync<NoContent>(HttpMethod.Delete, $"releases/{id}/rating/{username}", cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<MasterVersion>>> GetAllMasterVersionsAsync(long id, CancellationToken cancellationToken = default)
    => await connection.SendPagedRequestAsync<MasterVersion>(HttpMethod.Get, $"masters/{id}/versions", cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<ReleaseForArtist>>> GetAllReleasesForArtistAsync(long id, CancellationToken cancellationToken = default) => await connection.SendPagedRequestAsync<ReleaseForArtist>(HttpMethod.Get,
        $"artists/{id}/releases",
        cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<ReleaseForLabel>>> GetAllReleasesForLabelAsync(long id, CancellationToken cancellationToken = default)
    => await connection.SendPagedRequestAsync<ReleaseForLabel>(HttpMethod.Get, $"labels/{id}/releases", cancellationToken);

    public async Task<Artist> GetArtistAsync(long id, CancellationToken cancellationToken = default)
                            => await connection.SendRequestAsync<Artist>(HttpMethod.Get, $"artists/{id}", cancellationToken);

    public async Task<Label> GetLabelAsync(long id, CancellationToken cancellationToken = default)
    => await connection.SendRequestAsync<Label>(HttpMethod.Get, $"labels/{id}", cancellationToken);

    public async Task<Master> GetMasterAsync(long id, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<Master>(HttpMethod.Get,
        $"masters/{id}",
        cancellationToken);

    public async Task<PaginatedResponse<MasterVersion>> GetMasterVersionsAsync(long id,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default) => await connection.SendPagedRequestAsync<MasterVersion>(HttpMethod.Get, $"masters/{id}/versions", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{Constants.DefaultPage}",
            [Constants.PerPageQueryParameterName] = $"{Constants.DefaultPerPage}"
        }, cancellationToken);

    public async Task<Release> GetReleaseAsync(long id, CancellationToken cancellationToken = default)
                    => await this.GetReleaseAsync(id, Currency.DEFAULT, cancellationToken);

    public async Task<Release> GetReleaseAsync(long id, Currency currency, CancellationToken cancellationToken = default)
        => await connection.SendRequestAsync<Release>(HttpMethod.Get, $"releases/{id}", cancellationToken);

    public async Task<ReleaseRating> GetReleaseRatingAsync(long id, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<ReleaseRating>(HttpMethod.Get,
        $"releases/{id}/rating",
        cancellationToken);

    public async Task<ReleaseRatingByUser> GetReleaseRatingByUserAsync(long id, string username, CancellationToken cancellationToken = default) => await connection.SendRequestAsync<ReleaseRatingByUser>(HttpMethod.Get,
        $"releases/{id}/rating/{username}",
        cancellationToken);

    public async Task<PaginatedResponse<ReleaseForArtist>> GetReleasesForArtistAsync(long id,
                int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default)
        => await connection.SendPagedRequestAsync<ReleaseForArtist>(HttpMethod.Get, $"artists/{id}/releases", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{Constants.DefaultPage}",
            [Constants.PerPageQueryParameterName] = $"{Constants.DefaultPerPage}"
        }, cancellationToken);

    public async Task<PaginatedResponse<ReleaseForLabel>> GetReleasesForLabelAsync(long id,
        int page = Constants.DefaultPage,
        int perPage = Constants.DefaultPerPage,
        CancellationToken cancellationToken = default)
        => await connection.SendPagedRequestAsync<ReleaseForLabel>(HttpMethod.Get, $"labels/{id}/releases", new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = $"{Constants.DefaultPage}",
            [Constants.PerPageQueryParameterName] = $"{Constants.DefaultPerPage}"
        }, cancellationToken);

    public async Task<PaginatedResponse<SearchResult>> SearchAsync(SearchFilter filter, CancellationToken cancellationToken = default)
    => await connection.SendPagedRequestAsync<SearchResult>(HttpMethod.Get, "database/search", new Dictionary<string, string>(filter.AsDictionary()), cancellationToken);
}
