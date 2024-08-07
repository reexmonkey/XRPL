using System.Text.Json.Serialization;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.AmmInfo;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.RipplePathFind;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.SerializerContexts
{
    [JsonSerializable(typeof(AssetAmmInfoParameters))]
    [JsonSerializable(typeof(TokenAsset))]
    [JsonSerializable(typeof(XrpAsset))]
    [JsonSerializable(typeof(string))]
    public partial class AssetAmmInfoParametersContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(RipplePathFindParameters))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class RipplePathFindParametersContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(RiplePathFindResult))]
    [JsonSerializable(typeof(XrpAlternativePath))]
    [JsonSerializable(typeof(FungibleTokenAlternativePath))]
    public partial class RiplePathFindResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(AlternativePath))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class AlternativePathContext : JsonSerializerContext
    {
    }
}
