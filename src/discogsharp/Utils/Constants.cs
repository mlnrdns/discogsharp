using discogsharp.Domain;

namespace discogsharp.Utils;

public static class Constants
{
    public static readonly Uri DiscogsUri = new("https://api.discogs.com/");
    public const string DefaultUserAgent = "discogsharp (+https://github.com/mlnrdns/discogsharp)";
    public const string DefaultMediaType = "application/vnd.discogs.v2.discogs+json";
    public const string PageQueryParameterName = "page";
    public const string PerPageQueryParameterName = "per_page";
    public const int DefaultPage = 1;
    public const int DefaultPerPage = 100;
    public const string RateLimitTotal = "X-Discogs-Ratelimit";
    public const string RateLimitUsed = "X-Discogs-Ratelimit-Used";
    public const string RateLimitRemaining = "X-Discogs-Ratelimit-Remaining";

    public static readonly Dictionary<Type, string> ResourceMappings = new()
    {
        { typeof(ReleaseForArtist), "Releases" },
        { typeof(ReleaseForLabel), "Releases" },
        { typeof(MasterVersion), "Versions" },
        { typeof(SearchResult), "Results" },
        { typeof(CollectionItem), "Releases" },
        { typeof(Wants), "Wants" },
    };
}