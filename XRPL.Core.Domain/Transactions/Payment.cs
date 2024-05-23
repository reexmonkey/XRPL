using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;
using Path = XRPL.Core.Domain.Models.Path;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a a transfer of value from one account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/>Payments are also the only way to create accounts.
    /// </summary>
    public abstract class Payment : Transaction
    {
        protected PaymentFlags? flags;

        /// <summary>
        /// (Optional) Set of bit-flags for this transaction.
        /// </summary>
        public override uint? Flags { get => (uint?)flags; set => flags = (PaymentFlags?)value; }

        /// <summary>
        /// The unique address of the account receiving the payment.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// (Optional) Arbitrary tag that identifies the reason for the payment to the destination, or a hosted recipient to pay.
        /// </summary>
        public string? DestinationTag { get; set; }

        /// <summary>
        /// (Optional) Arbitrary tag that identifies the reason for the payment to the destination, or a hosted recipient to pay.
        /// </summary>
        public string? InvoiceID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        public Payment() : base(TransactionType.Payment)
        {
        }
    }

    /// <summary>
    /// Specifies a a transfer of value from one account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/>Payments are also the only way to create accounts.
    /// </summary>
    /// <typeparam name="TSourceCurrency">The type of source currency amount used in the transfer of value.</typeparam>
    /// <typeparam name="TSourceCurrency">The type of destination currency amount used in the transfer of value.</typeparam>
    public abstract class Payment<TSourceCurrency, TDestinationCurrency> : Payment
        where TSourceCurrency : class
        where TDestinationCurrency : class
    {
        /// <summary>
        /// (Optional) Minimum amount of destination currency this transaction should deliver. Only valid if this is a partial payment.
        /// For non-XRP amounts, the nested field names are lower-case.
        /// </summary>
        public TSourceCurrency? DeliverMin { get; set; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// For non-XRP amounts, the nested field names MUST be lower-case. Must be supplied for cross-currency/cross-issue payments.
        /// Must be omitted for XRP-to-XRP payments.
        /// </summary>
        public TDestinationCurrency? SendMax { get; set; }
    }

    /// <summary>
    /// Specifies a a transfer of value from one account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    /// <typeparam name="TAmount">The type of currency amount used in the transfer of value.</typeparam>
    public abstract class V1Payment<TSourceCurrency, TDestinationCurrency> : Payment<TSourceCurrency, TDestinationCurrency>
        where TSourceCurrency : class
        where TDestinationCurrency : class
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// <para/>For non-XRP amounts, the nested field names MUST be lower-case.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public required TSourceCurrency Amount { get; set; }
    }

    /// <summary>
    /// Specifies a a transfer of value from one account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    /// <typeparam name="TSourceCurrency">The type of source currency amount used in the transfer of value.</typeparam>
    /// <typeparam name="TSourceCurrency">The type of destination currency amount used in the transfer of value.</typeparam>
    public abstract class V2Payment<TSourceCurrency, TDestinationCurrency> : Payment<TSourceCurrency, TDestinationCurrency>
        where TSourceCurrency : class
        where TDestinationCurrency : class
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// <para/>For non-XRP amounts, the nested field names MUST be lower-case.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public required TSourceCurrency DeliverMax { get; set; }
    }

    #region API V1 Payments
    /// <summary>
    /// Represents a a transfer of value from one XRP account to another.
    /// <para/>Transfers XRP directly from one account to another, using one transaction.
    /// Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class DirectXrpV1Payment : V1Payment<string, string>
    {
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// Increases or decreases the amount of a non-XRP currency or asset tracked in the XRP Ledger.
    /// Transfer fees and freezes do not apply when sending and redeeming directly.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class CreateOrRedeemTokensV1Payment : V1Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class XrpFungibleTokenCrossCurrencyV1Payment : V1Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenXrpCrossCurrencyV1Payment : V1Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenCrossCurrencyV1Payment : V1Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class XrpFungibleTokenV1PartialPayment : V1Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XrpFungibleTokenV1PartialPayment"/> class.
        /// </summary>
        public XrpFungibleTokenV1PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenXrpV1PartialPayment : V1Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenXrpV1PartialPayment"/> class.
        /// </summary>
        public FungibleTokenXrpV1PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenV1PartialPayment : V1Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenV1PartialPayment"/> class.
        /// </summary>
        public FungibleTokenV1PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert XRP to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class XrpFungibleTokenV1CurrencyConversion : V1Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to XRP, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenXrpV1CurrencyConversion : V1Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public sealed class FungibleTokenV1CurrencyConversion : V1Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }
    #endregion

    #region API V2 Payments
    /// <summary>
    /// Represents a a transfer of value from one XRP account to another.
    /// <para/>Transfers XRP directly from one account to another, using one transaction.
    /// Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class DirectXrpV2Payment : V2Payment<string, string>
    {
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// Increases or decreases the amount of a non-XRP currency or asset tracked in the XRP Ledger.
    /// Transfer fees and freezes do not apply when sending and redeeming directly.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class CreateOrRedeemTokensV2Payment : V2Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class XrpFungibleTokenCrossCurrencyV2Payment : V2Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenXrpCrossCurrencyV2Payment : V2Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenCrossCurrencyV2Payment : V2Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public Path[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class XrpFungibleTokenV2PartialPayment : V2Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XrpFungibleTokenV2PartialPayment"/> class.
        /// </summary>
        public XrpFungibleTokenV2PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenXrpV2PartialPayment : V2Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenXrpV2PartialPayment"/> class.
        /// </summary>
        public FungibleTokenXrpV2PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenV2PartialPayment : V2Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][]? Paths { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenV2PartialPayment"/> class.
        /// </summary>
        public FungibleTokenV2PartialPayment()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert XRP to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class XrpFungibleTokenV2CurrencyConversion : V2Payment<string, TokenAmount>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to XRP, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenXrpV2CurrencyConversion : V2Payment<TokenAmount, string>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public sealed class FungibleTokenV2CurrencyConversion : V2Payment<TokenAmount, TokenAmount>
    {
        /// <summary>
        /// (Auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required Path[][] Paths { get; set; }
    }
    #endregion

    /// <summary>
    /// Represents the flags of a <see cref="Payment"/> transaction
    /// </summary>
    public enum PaymentFlags
    {
        /// <summary>
        /// Do not use the default path; only use paths included in the Paths field.
        /// This is intended to force the transaction to take arbitrage opportunities.
        /// Most clients do not need this.
        /// </summary>
        tfNoRippleDirect = 0x00010000,

        /// <summary>
        /// If the specified Amount cannot be sent without spending more than SendMax, reduce the received amount instead of failing outright.
        /// See Partial Payments for more details.
        /// </summary>
        tfPartialPayment = 0x00020000,

        /// <summary>
        /// Only take paths where all the conversions have an input:output ratio that is equal or better than the ratio of Amount:SendMax.
        /// See Limit Quality for details.
        /// </summary>
        tfLimitQuality = 0x00040000
    }
}