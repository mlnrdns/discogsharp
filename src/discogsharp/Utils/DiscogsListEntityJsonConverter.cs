using discogsharp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace discogsharp.Utils;

public class DiscogsListEntityJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(DiscogsListEntity).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
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

    protected static DiscogsListEntity Create(Type objectType, JObject jObject)
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
            "artist" => new ArtistDiscogsListEntity(),
            "label" => new LabelDiscogsListEntity(),
            "master" => new MasterDiscogsListEntity(),
            "release" => new ReleaseDiscogsListEntity(),
            _ => throw new Exception($"The given result type {jObject["type"]} is not supported!"),
        };
    }
}
