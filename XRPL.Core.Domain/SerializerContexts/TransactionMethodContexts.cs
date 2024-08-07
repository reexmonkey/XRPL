using System.Text.Json.Serialization;
using XRPL.Core.Domain.Methods.TransactionMethods.Submit;
using XRPL.Core.Domain.Methods.TransactionMethods.SubmitMultisigned;
using XRPL.Core.Domain.Methods.TransactionMethods.TransactionEntry;
using XRPL.Core.Domain.Methods.TransactionMethods.Tx;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.SerializerContexts
{
    [JsonSerializable(typeof(SubmitResult))]
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
    public partial class SubmitResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(SubmitMultisignedResult))]
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
    public partial class SubmitMultisignedResultContext : JsonSerializerContext
    {
    }


    [JsonSerializable(typeof(TransactionEntryResult))]
    [JsonSerializable(typeof(XrpTransactionMetadata))]
    [JsonSerializable(typeof(FungibleTokenTransactionMetadata))]
    public partial class TransactionEntryResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(TxResult))]
    [JsonSerializable(typeof(TransactionMetadata))]
    [JsonSerializable(typeof(string))]
    public partial class TxResultContext : JsonSerializerContext
    {
    }

    [JsonSerializable(typeof(TxResult))]
    [JsonSerializable(typeof(XrpTransactionMetadata))]
    [JsonSerializable(typeof(FungibleTokenTransactionMetadata))]
    public partial class JsonTxResultContext : JsonSerializerContext
    {
    }
}
