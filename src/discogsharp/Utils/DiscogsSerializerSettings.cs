using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace discogsharp.Utils;

internal class DiscogsSerializerSettings : JsonSerializerSettings
{
    public static JsonSerializerSettings Default = new DiscogsSerializerSettings();

    public DiscogsSerializerSettings()
    {
        Converters.Add(new StringEnumConverter());
        Converters.Add(new DiscogsSearchJsonConverter());
        ContractResolver = new DiscogsContractResolver();
    }
}
