using discogsharp.Domain;
using discogsharp.Utils;

namespace discogsharp.Services;

public interface IDatabaseService
{
    Task<Artist> GetArtistAsync(int id, CancellationToken cancellationToken = default);

    Task<Release> GetReleaseAsync(int id, CancellationToken cancellationToken = default);

    Task<Release> GetReleaseAsync(int id, Currency currency, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<ReleaseForArtist>> GetReleasesForArtistAsync(int id, int page = Constants.DefaultPage, int perPage = Constants.DefaultPerPage, CancellationToken cancellation = default);

    Task<IEnumerable<PaginatedResponse<ReleaseForArtist>>> GetAllReleasesForArtistAsync(int id, CancellationToken cancellationToken = default);

    Task<ReleaseRating> GetReleaseRatingAsync(int id, CancellationToken cancellationToken = default);

    Task<ReleaseRatingByUser> GetReleaseRatingByUserAsync(int id, string username, CancellationToken cancellationToken = default);
    Task<ReleaseRatingByUser> AddOrUpdateReleaseRatingByUserAsync(int id, string username, int rating, CancellationToken cancellationToken = default);
    Task<ReleaseRatingByUser> DeleteReleaseRatingByUserAsync(int id, string username, CancellationToken cancellationToken = default);
    Task<Master> GetMasterAsync(int id, CancellationToken cancellationToken = default);

    Task<PaginatedResponse<MasterVersion>> GetMasterVersionsAsync(int id, int page = Constants.DefaultPage, int perPage = Constants.DefaultPerPage, CancellationToken cancellationToken = default);

    Task<IEnumerable<PaginatedResponse<MasterVersion>>> GetAllMasterVersionsAsync(int id, CancellationToken cancellationToken = default);
    Task<Label> GetLabelAsync(int id, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<ReleaseForLabel>> GetReleasesForLabelAsync(int id,
            int page = Constants.DefaultPage,
            int perPage = Constants.DefaultPerPage,
            CancellationToken cancellationToken = default);
    Task<IEnumerable<PaginatedResponse<ReleaseForLabel>>> GetAllReleasesForLabelAsync(int id, CancellationToken cancellationToken = default);
    Task<PaginatedResponse<SearchResult>> SearchAsync(SearchFilter filter, CancellationToken cancellationToken = default);
}