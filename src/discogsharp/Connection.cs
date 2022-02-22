using System.Net.Http.Headers;
using discogsharp.Domain;
using discogsharp.Utils;
using Newtonsoft.Json;

namespace discogsharp;

public abstract class Connection
{
    public static HttpClient HttpClient { get; set; } = null!;
    public string? RequestAuthorization { get; set; }
    protected string UserAgent { get; }

    protected Connection(string userAgent, HttpClient httpClient)
    {
        this.UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.DefaultMediaType));
        HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(this.UserAgent);
        HttpClient.BaseAddress = Constants.DiscogsUri;
    }

    protected Connection(HttpClient httpClient) : this(Constants.DefaultUserAgent, httpClient)
    {
    }

    protected Connection(string userAgent) : this(userAgent, new HttpClient())
    {
        this.UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
    }

    protected Connection() : this(Constants.DefaultUserAgent)
    {
    }

    public async Task<byte[]> GetByteArrayAsync(string uri, CancellationToken cancellationToken = default) => await HttpClient!.GetByteArrayAsync(uri, cancellationToken);

    public async Task<PaginatedResponse<T>> SendPagedRequestAsync<T>(HttpMethod method, string path, Dictionary<string, string>? queryStringParameters, CancellationToken cancellationToken = default)
    => await SendRequestAsync<PaginatedResponse<T>>(method, path, queryStringParameters, cancellationToken);

    public async Task<IEnumerable<PaginatedResponse<T>>> SendPagedRequestAsync<T>(HttpMethod method, string path, CancellationToken cancellationToken = default)
    {
        var queryParameters = new Dictionary<string, string>()
        {
            [Constants.PageQueryParameterName] = "1",
            [Constants.PerPageQueryParameterName] = "100"
        };

        var firstResponse = await SendRequestAsync<PaginatedResponse<T>>(method, path, queryParameters, cancellationToken);

        var totalPages = firstResponse.Pagination.Pages;

        return totalPages < 2
            ? firstResponse.AsEnumerable()
            : (await Task.WhenAll(Enumerable
                .Range(2, totalPages - 1)
                .Select(async p =>
                {
                    queryParameters[Constants.PageQueryParameterName] = $"{p}";
                    return await this.SendRequestAsync<PaginatedResponse<T>>(method, path, queryParameters, cancellationToken);
                })
                ))
                .Prepend(firstResponse);
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string path, StringContent? content, Dictionary<string, string>? queryStringParameters, CancellationToken cancellationToken = default) where T : class
    {
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(path.ExtendPathWithQueryString(queryStringParameters), UriKind.Relative),
            Content = content ?? default
        };

        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Discogs", this.RequestAuthorization);
        var httpResponseMessage = await HttpClient!.SendAsync(httpRequestMessage,
        HttpCompletionOption.ResponseContentRead, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<T>(responseContent, DiscogsSerializerSettings.Default);
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string path, CancellationToken cancellationToken = default) where T : class
    {
        return await this.SendRequestAsync<T>(method, path, null, null, cancellationToken);
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string path, StringContent content, CancellationToken cancellationToken = default) where T : class
    {
        return await this.SendRequestAsync<T>(method, path, content, null, cancellationToken);
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string path, Dictionary<string, string>? queryStringParameters, CancellationToken cancellationToken = default) where T : class
    {
        return await this.SendRequestAsync<T>(method, path, null, queryStringParameters, cancellationToken);
    }
}
