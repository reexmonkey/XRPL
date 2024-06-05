using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Helpers.JsonSerializerContexts
{

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(LedgerEntryBase))]
    public partial class LedgerEntryBaseContext : JsonSerializerContext
    {
    }


    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(AccountRoot))]
    public partial class AccountRootContext : JsonSerializerContext
    {
    }



    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(AmmAccountRoot))]
    public partial class AmmAccountRootContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(AMM))]
    public partial class AMMContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Ammendments))]
    public partial class AmmendmentsContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Bridge))]
    public partial class BridgeContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Check))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(TokenAmount))]
    public partial class CheckContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XrpCheck))]
    public partial class XrpCheckContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenCheck))]
    public partial class FungibleTokenCheckContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(DepositPreauthEntry))]
    public partial class DepositPreauthEntryContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(DID))]
    public partial class DIDContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(DirectoryNode))]
    public partial class DirectoryNodeContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Escrow))]
    public partial class EscrowContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FeeSettings))]
    public partial class FeeSettingsContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(LedgerHashes))]
    public partial class LedgerHashesContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(NegativeUNL))]
    public partial class NegativeUNLContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(NFTokenOffer))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(TokenAmount))]
    public partial class NFTokenOfferContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XrpForNFTokenOffer))]
    public partial class XrpForNFTokenOfferContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenForNFTokenOffer))]
    public partial class FungibleTokenForNFTokenOfferContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(NFTokenPage))]
    public partial class NFTokenPageContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Offer))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(TokenAmount))]
    public partial class OfferContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XrpForFungibleTokenOffer))]
    public partial class XrpForFungibleTokenOfferContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenForXrpOffer))]
    public partial class FungibleTokenForXrpOfferContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenOffer))]
    public partial class FungibleTokenOfferContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(PayChannel))]
    public partial class PayChannelContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(RippleState))]
    public partial class RippleStateContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(SignerList))]
    public partial class SignerListContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Ticket))]
    public partial class TicketContext : JsonSerializerContext
    {

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XChainOwnedClaimID))]
    [JsonSerializable(typeof(XrpXChainClaimAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainClaimAttestation))]
    public partial class XChainOwnedClaimIDContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XrpXChainClaimAttestation))]
    public partial class XrpXChainClaimAttestationContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenXChainClaimAttestation))]
    public partial class FungibleTokenXChainClaimAttestationContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XChainCreateAccountAttestation))]
    [JsonSerializable(typeof(XrpXChainCreateAccountAttestation))]
    [JsonSerializable(typeof(FungibleTokenXChainCreateAccountAttestation))]
    public partial class XChainOwnedCreateAccountClaimIDContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(XrpXChainCreateAccountAttestation))]
    public partial class XrpXChainCreateAccountAttestationContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(FungibleTokenXChainCreateAccountAttestation))]
    public partial class FungibleTokenXChainCreateAccountAttestationContext : JsonSerializerContext
    {
    }
}