using discogsharp.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace discogsharp.Utils;

public class DiscogsContractResolver : DefaultContractResolver
{
    public DiscogsContractResolver()
    {
        NamingStrategy = new SnakeCaseNamingStrategy();
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (typeof(PaginatedResponse).GetTypeInfo().IsAssignableFrom(member.DeclaringType?.GetTypeInfo()) && member.Name == "Items")
        {
            var resourceType = member.DeclaringType.GenericTypeArguments[0];
            property.PropertyName = Constants.ResourceMappings[resourceType];
        }

        return property;
    }
}