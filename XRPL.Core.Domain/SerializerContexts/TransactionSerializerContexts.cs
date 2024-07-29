using System.Text.Json.Serialization;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.SerializerContexts
{

    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(XrpFungibleTokenAMMCreate))]
    [JsonSerializable(typeof(FungibleTokenXrpAMMCreate))]
    [JsonSerializable(typeof(FungibleTokenAMMCreate))]
    public partial class AMMCreateContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(AMMDeposit))]
    [JsonSerializable(typeof(XrpFungibleTokenAMMDeposit))]
    [JsonSerializable(typeof(FungibleTokenXrpAMMDeposit))]
    [JsonSerializable(typeof(FungibleTokenAMMDeposit))]
    public partial class AMMDepositContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(AMMWithdraw))]
    [JsonSerializable(typeof(XrpFungibleTokenAMMWithdraw))]
    [JsonSerializable(typeof(FungibleTokenXrpAMMWithdraw))]
    [JsonSerializable(typeof(FungibleTokenAMMWithdraw))]
    public partial class AMMWithdrawContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(CheckCash))]
    [JsonSerializable(typeof(XrpCheckCash))]
    [JsonSerializable(typeof(FungibleTokenCheckCash))]
    public partial class CheckCashContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(CheckCreate))]
    [JsonSerializable(typeof(XrpCheckCreate))]
    [JsonSerializable(typeof(FungibleTokenCheckCreate))]
    public partial class CheckCreateContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(BrokeredModeNFTokenAcceptOffer))]
    [JsonSerializable(typeof(XrpBrokeredModeNFTokenAcceptOffer))]
    [JsonSerializable(typeof(FungibleTokenBrokeredModeNFTokenAcceptOffer))]
    [JsonSerializable(typeof(DirectModeNFTokenBuyOffer))]
    [JsonSerializable(typeof(DirectModeNFTokenSellOffer))]
    public partial class BrokeredModeNFTokenAcceptOfferContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(NFTokenCreateOffer))]
    [JsonSerializable(typeof(XrpNFTokenCreateOffer))]
    [JsonSerializable(typeof(FungibleTokenNFTokenCreateOffer))]
    public partial class NFTokenCreateOfferContext : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(OfferCreate))]
    [JsonSerializable(typeof(XrpForFungibleTokenOfferCreate))]
    [JsonSerializable(typeof(FungibleTokenForXrpOfferCreate))]
    [JsonSerializable(typeof(FungibleTokenOfferCreate))]
    public partial class OfferCreateContext : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(PaymentV1))]
    [JsonSerializable(typeof(DirectXrpPaymentV1))]
    [JsonSerializable(typeof(CreateOrRedeemTokensPaymentV1))]
    [JsonSerializable(typeof(XrpCrossCurrencyPaymentV1))]
    [JsonSerializable(typeof(XrpPartialPaymentV1))]
    [JsonSerializable(typeof(FungibleTokenPartialPaymentV1))]
    [JsonSerializable(typeof(XrpCurrencyConversionV1))]
    [JsonSerializable(typeof(FungibleTokenCurrencyConversionV1))]
    public partial class PaymentV1Context : JsonSerializerContext
    {

    }

    [JsonSerializable(typeof(PaymentV2))]
    [JsonSerializable(typeof(DirectXrpPaymentV1))]
    [JsonSerializable(typeof(CreateOrRedeemTokensPaymentV2))]
    [JsonSerializable(typeof(XrpCrossCurrencyPaymentV2))]
    [JsonSerializable(typeof(FungibleTokenCrossCurrencyPaymentV2))]
    [JsonSerializable(typeof(XrpPartialPaymentV2))]
    [JsonSerializable(typeof(FungibleTokenPartialPaymentV2))]
    [JsonSerializable(typeof(XrpCurrencyConversionV2))]
    [JsonSerializable(typeof(FungibleTokenCurrencyConversionV2))]
    public partial class PaymentV2Context : JsonSerializerContext
    {

    }


    [JsonSerializable(typeof(XrpTransactionMetadata))]
    [JsonSerializable(typeof(XrpTransactionMetadata))]
    [JsonSerializable(typeof(FungibleTokenTransactionMetadata))]
    public partial class TransactionMetadataContext : JsonSerializerContext
    {

    }


}
