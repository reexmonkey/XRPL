using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.SerializerContexts
{

    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class AMMCreateContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(AMMDeposit))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class AMMDepositContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(AMMWithdraw))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class AMMWithdrawContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(CheckCash))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class CheckCashContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(CheckCreate))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class CheckCreateContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(BrokeredModeNFTokenAcceptOffer))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class BrokeredModeNFTokenAcceptOfferContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(NFTokenCreateOffer))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class NFTokenCreateOfferContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(OfferCreate))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class OfferCreateContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(PaymentV1))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class PaymentV1Context : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(PaymentV2))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class PaymentV2Context : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(TransactionMetadata))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(string))]
    public partial class TransactionMetadataContext : JsonSerializerContext
    {

    }


}
