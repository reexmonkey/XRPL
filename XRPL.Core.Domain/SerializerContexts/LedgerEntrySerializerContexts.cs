using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.SerializerContexts
{

    [JsonSerializable(typeof(Check))]
    [JsonSerializable(typeof(XrpCheck))]
    [JsonSerializable(typeof(FungibleTokenCheck))]
    public partial class CheckContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(NFTokenOffer))]
    [JsonSerializable(typeof(XrpForNFTokenOffer))]
    [JsonSerializable(typeof(FungibleTokenForNFTokenOffer))]
    public partial class NFTokenOfferContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(Offer))]
    [JsonSerializable(typeof(XrpForFungibleTokenOffer))]
    [JsonSerializable(typeof(FungibleTokenForXrpOffer))]
    [JsonSerializable(typeof(FungibleTokenOffer))]
    public partial class OfferContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(XChainClaimAttestation))]
    [JsonSerializable(typeof(XrpXChainClaimAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainClaimAttestation))]
    public partial class XChainClaimAttestationContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(XChainCreateAccountAttestation))]
    [JsonSerializable(typeof(XrpXChainCreateAccountAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainCreateAccountAttestation))]
    public partial class XChainCreateAccountAttestationContext : JsonSerializerContext
    {
    }


}
