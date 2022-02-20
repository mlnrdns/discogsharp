using discogsharp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace discogsharp.Utils;

public class DiscogsSearchJsonConverter : JsonConverter
{
    protected static SearchResult Create(Type objectType, JObject jObject)
    {
        if (objectType is null)
        {
            throw new ArgumentNullException(nameof(objectType));
        }

        if (jObject is null)
        {
            throw new ArgumentNullException(nameof(jObject));
        }

        return (jObject["type"]?.ToString().ToLowerInvariant()) switch
        {
            "artist" => new ArtistSearchResult(),
            "label" => new LabelSearchResult(),
            "master" => new MasterSearchResult(),
            "release" => new ReleaseSearchResult(),
            _ => throw new Exception($"The given result type {jObject["type"]} is not supported!"),
        };
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(SearchResult).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);
        var target = Create(objectType, jObject);
        serializer.Populate(jObject.CreateReader(), target);
        return target;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}