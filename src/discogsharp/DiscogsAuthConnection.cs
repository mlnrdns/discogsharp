namespace discogsharp;

public sealed class DiscogsAuthConnection : Connection
{
    private DiscogsAuthConnection() : base()
    {
    }

    private DiscogsAuthConnection(HttpClient httpClient) : base(httpClient)
    {
    }

    private DiscogsAuthConnection(string userAgent) : base(userAgent)
    {
    }

    private DiscogsAuthConnection(string userAgent, HttpClient httpClient) : base(userAgent, httpClient)
    {
    }

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken) => new()
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken, HttpClient httpClient) => new(httpClient)
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken, string userAgent) => new(userAgent)
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithPersonalAccessToken(string personalAccessToken, string userAgent, HttpClient httpClient) => new(userAgent, httpClient)
    {
        RequestAuthorization = $"token={personalAccessToken}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret) => new()
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret, HttpClient httpClient) => new(httpClient)
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret, string userAgent) => new(userAgent ?? throw new ArgumentNullException(nameof(userAgent)))
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };

    public static DiscogsAuthConnection WithKeyAndSecret(string key, string secret, string userAgent, HttpClient httpClient) => new(userAgent, httpClient)
    {
        RequestAuthorization = $"key={key}, secret={secret}"
    };
}