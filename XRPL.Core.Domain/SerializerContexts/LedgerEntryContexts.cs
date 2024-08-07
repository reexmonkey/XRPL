using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.SerializerContexts
{
    [JsonSerializable(typeof(Check))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class CheckContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(NFTokenOffer))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class NFTokenOfferContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(Offer))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class OfferContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(XChainOwnedClaimID))]
    [JsonSerializable(typeof(XrpXChainClaimAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainClaimAttestation))]
    public partial class XChainOwnedClaimIDContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(XChainClaimAttestation))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class XChainClaimAttestationContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(XChainCreateAccountAttestation))]
    [JsonSerializable(typeof(XrpXChainCreateAccountAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainCreateAccountAttestation))]
    public partial class XChainOwnedCreateAccountClaimIDContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(XChainCreateAccountAttestation))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class XChainCreateAccountAttestationContext : JsonSerializerContext
    {
    }
}
