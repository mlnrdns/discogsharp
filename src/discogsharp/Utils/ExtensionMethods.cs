using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace discogsharp.Utils;

public static class ExtensionMethods
{
    public static IEnumerable<T> AsEnumerable<T>(this T item)
    {
        yield return item;
    }

    public static string ExtendPathWithQueryString(this string path, Dictionary<string, string> queryStringParameters)
    {
        if (queryStringParameters == null || queryStringParameters?.Count == 0)
            return path;

        bool startingQuestionMarkAdded = false;
        StringBuilder? sb = new();
        sb.Append(path);
        foreach (var parameter in queryStringParameters!)
        {
            if (parameter.Value == null)
            {
                continue;
            }

            sb.Append(startingQuestionMarkAdded ? '&' : '?');
            sb.Append(parameter.Key);
            sb.Append('=');
            sb.Append(parameter.Value);
            startingQuestionMarkAdded = true;
        }

        return sb.ToString();
    }

    public static Dictionary<string, string> AsDictionary(this object source)
    {
        if (source == null)
            return null;

        return JObject.FromObject(source, JsonSerializer.CreateDefault(DiscogsSerializerSettings.Default))
            .Properties()
            .Where(x => !(x.Value.Type == JTokenType.Null || string.IsNullOrWhiteSpace(x.Value.ToString()) || x.Value.ToString().Equals("NONE", StringComparison.OrdinalIgnoreCase)))
            .ToDictionary(x => x.Name, x => x.Value.ToString());
    }
}