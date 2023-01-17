using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services;

public interface IDatabaseService
{
    Task<ReleaseRatingByUser> AddOrUpdateReleaseRatingByUserAsync(long id, string username, int rating, CancellationToken cancellationToken = default);

    Task<NoContent> DeleteReleaseRatingByUserAsync(long id, string username, CancellationToken cancellationToken = default);

    Task<IEnumerable<PaginatedResponse<MasterVersion>>> GetAllMasterVersionsAsync(long id, CancellationToken cancellationToken = default);

    Task<IEnumerable<PaginatedResponse<ReleaseForArtist>>> GetAllReleasesForArtistAsync(long id, CancellationToken cancellationToken = default);

    Task<IEnumerable<PaginatedResponse<ReleaseForLabel>>> GetAllReleasesForLabelAsync(long id, CancellationToken cancellationToken = default);

    Task<Artist> GetArtistAsync(long id, CancellationToken cancellationToken = default);

    Task<Label> GetLabelAsync(long id, CancellationToken cancellationToken = default);

    Task<Master> GetMasterAsync(long id, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<MasterVersion>> GetMasterVersionsAsync(long id, int page = Constants.DefaultPage, int perPage = Constants.DefaultPerPage, CancellationToken cancellationToken = default);

    Task<Release> GetReleaseAsync(long id, CancellationToken cancellationToken = default);

    Task<Release> GetReleaseAsync(long id, Currency currency, CancellationToken cancellationToken = default);

    Task<ReleaseRating> GetReleaseRatingAsync(long id, CancellationToken cancellationToken = default);

    Task<ReleaseRatingByUser> GetReleaseRatingByUserAsync(long id, string username, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<ReleaseForArtist>> GetReleasesForArtistAsync(long id, int page = Constants.DefaultPage, int perPage = Constants.DefaultPerPage, CancellationToken cancellation = default);

    Task<PaginatedResponse<ReleaseForLabel>> GetReleasesForLabelAsync(long id,
            int page = Constants.DefaultPage,
            int perPage = Constants.DefaultPerPage,
            CancellationToken cancellationToken = default);

    Task<PaginatedResponse<SearchResult>> SearchAsync(SearchFilter filter, CancellationToken cancellationToken = default);
}
