using System.Net.Http.Headers;
namespace discogsharp.Utils;

public class RateLimit
{
    public int Total { get; set; }
    public int Used { get; set; }
    public int Remaining { get; set; }

    public RateLimit(HttpResponseMessage response)
    {
        var headers = response?.Headers;

        Total = GetValueFromHeader(headers, Constants.RateLimitTotal);
        Used = GetValueFromHeader(headers, Constants.RateLimitUsed);
        Remaining = GetValueFromHeader(headers, Constants.RateLimitRemaining);
    }

    private static int GetValueFromHeader(HttpResponseHeaders? headers, string key)
    {
        if (headers?.Any() != true)
            return 0;

        if (headers.TryGetValues(key, out var values) && int.TryParse(values.FirstOrDefault(), out int value))
        {
            return value;
        }

        return 0;
    }
}
