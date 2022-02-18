namespace discogsharp;

public sealed class DiscogsAuthConnection : Connection
{
    private DiscogsAuthConnection() : base()
    {
    }

    private DiscogsAuthConnection(string userAgent) : base(userAgent)
    {
    }

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken) => new()
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken, string userAgent) => new(userAgent ?? throw new ArgumentNullException(nameof(userAgent)))
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret) => new()
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret, string userAgent) => new(userAgent ?? throw new ArgumentNullException(nameof(userAgent)))
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };
}