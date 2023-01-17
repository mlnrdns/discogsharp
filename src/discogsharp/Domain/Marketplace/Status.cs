using System.Runtime.Serialization;

namespace discogsharp.Domain
{
    public enum Status
    {
        [EnumMember(Value = "Draft")]
        Draft,

        [EnumMember(Value = "For Sale")]
        ForSale,
    }
}
