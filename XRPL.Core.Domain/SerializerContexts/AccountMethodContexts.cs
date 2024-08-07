using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Methods.AccountMethods.AccountObjects;
using XRPL.Core.Domain.Methods.AccountMethods.AccountOffers;
using XRPL.Core.Domain.Methods.AccountMethods.NoRippleCheck;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.SerializerContexts
{
    [JsonSerializable(typeof(AccountObjectsResult))]
    [JsonSerializable(typeof(AccountRoot))]
    [JsonSerializable(typeof(AMM))]
    [JsonSerializable(typeof(Ammendments))]
    [JsonSerializable(typeof(Bridge))]
    [JsonSerializable(typeof(Check))]
    [JsonSerializable(typeof(DepositPreauthEntry))]
    [JsonSerializable(typeof(DID))]
    [JsonSerializable(typeof(DirectoryNode))]
    [JsonSerializable(typeof(Escrow))]
    [JsonSerializable(typeof(FeeSettings))]
    [JsonSerializable(typeof(LedgerHashes))]
    [JsonSerializable(typeof(NegativeUNL))]
    [JsonSerializable(typeof(NFTokenOffer))]
    [JsonSerializable(typeof(NFTokenPage))]
    [JsonSerializable(typeof(Offer))]
    [JsonSerializable(typeof(PayChannel))]
    [JsonSerializable(typeof(RippleState))]
    [JsonSerializable(typeof(SignerList))]
    [JsonSerializable(typeof(Ticket))]
    [JsonSerializable(typeof(XChainOwnedClaimID))]
    [JsonSerializable(typeof(XChainOwnedCreateAccountClaimID))]
    public partial class AccountObjectsResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(AccountOffersResult))]
    [JsonSerializable(typeof(XrpForTokenAccountOffer))]
    [JsonSerializable(typeof(TokenForXrpAccountOffer))]
    [JsonSerializable(typeof(TokenForTokenAccountOffer))]
    public partial class AccountOffersResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(AccountOffer))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class AccountOfferContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(NoRippleCheckResult))]
    [JsonSerializable(typeof(AccountDelete))]
    [JsonSerializable(typeof(AccountSet))]
    [JsonSerializable(typeof(AMMBid))]
    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(AMMDelete))]
    [JsonSerializable(typeof(AMMDeposit))]
    [JsonSerializable(typeof(AMMVote))]
    [JsonSerializable(typeof(AMMWithdraw))]
    [JsonSerializable(typeof(CheckCancel))]
    [JsonSerializable(typeof(CheckCash))]
    [JsonSerializable(typeof(CheckCreate))]
    [JsonSerializable(typeof(Clawback))]
    [JsonSerializable(typeof(DepositPreauth))]
    [JsonSerializable(typeof(DIDDelete))]
    [JsonSerializable(typeof(EscrowCancel))]
    [JsonSerializable(typeof(EscrowCreate))]
    [JsonSerializable(typeof(EscrowFinish))]
    [JsonSerializable(typeof(BrokeredModeNFTokenAcceptOffer))]
    [JsonSerializable(typeof(DirectModeNFTokenBuyOffer))]
    [JsonSerializable(typeof(DirectModeNFTokenSellOffer))]
    [JsonSerializable(typeof(NFTokenBurn))]
    [JsonSerializable(typeof(NFTokenCancelOffer))]
    [JsonSerializable(typeof(NFTokenCreateOffer))]
    [JsonSerializable(typeof(NFTokenMint))]
    [JsonSerializable(typeof(NFTokenMint))]
    [JsonSerializable(typeof(OfferCancel))]
    [JsonSerializable(typeof(OfferCreate))]
    [JsonSerializable(typeof(Payment))]
    [JsonSerializable(typeof(PaymentChannelClaim))]
    [JsonSerializable(typeof(PaymentChannelFund))]
    [JsonSerializable(typeof(SetRegularKey))]
    [JsonSerializable(typeof(SignerListSet))]
    [JsonSerializable(typeof(TicketCreate))]
    [JsonSerializable(typeof(TrustSet))]
    [JsonSerializable(typeof(XChainAccountCreateCommit))]
    public partial class NoRippleCheckResultContext : JsonSerializerContext
    {

    }


}
