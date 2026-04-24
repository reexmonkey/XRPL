using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a a transfer of value from one account to another. (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/> Payments are also the only way to create accounts.
    /// </summary>
    public abstract class Payment : Transaction
    {
        protected PaymentFlags? flags;

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

        public override uint? Flags { get => (uint?)flags; set => flags = (PaymentFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        public Payment() : base(TransactionType.Payment)
        {
        }
    }

    #region API V1 Payments

    /// <summary>
    /// Transfers XRP directly from one account to another, using one transaction. Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// </summary>
    public sealed class DirectXRPPaymentV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required XRPAmount Amount { get; set; }
    }

    /// <summary>
    /// Increases or decreases the amount of a non-XRP currency or asset tracked in the XRP Ledger. Transfer fees and freezes do not apply when sending and redeeming directly.
    /// </summary>
    public sealed class CreateOrRedeemTokensV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// <para/> The nested field names MUST be lower-case. If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public required TokenAmount Amount { get; set; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction. For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[]? Paths { get; set; }
    }

    /// <summary>
    /// Send tokens from one holder to another.
    /// The Amount or SendMax can be XRP or tokens, but can't both be XRP.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies, or currencies with the same currency code and different issuers.
    /// </summary>
    public sealed class CrossCurrencyPaymentV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount Amount { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/> Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }
    }

    /// <summary>
    /// Sends up to a specific amount of any currency.
    /// Uses the <see cref="PaymentFlags.tfPartialPayment"/> flag.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful; if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// </summary>
    public sealed class PartialPaymentV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount Amount { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/> Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }

        /// <summary>
        /// Minimum amount of destination currency this transaction should deliver.
        /// </summary>
        public CurrencyAmount? DeliverMin { get; set; }

        public PartialPaymentV1()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert one currency to another, possibly taking arbitrage opportunities.
    /// The Amount and SendMax cannot both be XRP.
    /// Also called a circular payment because it delivers money to the sender. This type of transaction may be classified as an "exchange" and not a "payment".
    /// </summary>
    public sealed class CurrencyConversionV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount Amount { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }
    }

    /// <summary>
    /// Send MPTs to a holder.
    /// </summary>
    public sealed class MPTPaymentV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required MPTAmount Amount { get; set; }
    }

    #endregion API V1 Payments

    #region API V2 Payments

    /// <summary>
    /// Transfers XRP directly from one account to another, using one transaction. Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// </summary>
    public sealed class DirectXRPPaymentV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required XRPAmount DeliverMax { get; set; }
    }

    /// <summary>
    /// Send tokens from one holder to another.
    /// The Amount or SendMax can be XRP or tokens, but can't both be XRP.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies, or currencies with the same currency code and different issuers.
    /// </summary>
    public sealed class CreateOrRedeemTokensV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required TokenAmount DeliverMax { get; set; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction. For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[]? Paths { get; set; }
    }

    public sealed class CrossCurrencyPaymentV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount DeliverMax { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }
    }

    /// <summary>
    /// Sends up to a specific amount of any currency.
    /// Uses the <see cref="PaymentFlags.tfPartialPayment"/> flag.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful; if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// </summary>
    public sealed class PartialPaymentV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount DeliverMax { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }

        /// <summary>
        /// Minimum amount of destination currency this transaction should deliver.
        /// </summary>
        public CurrencyAmount? DeliverMin { get; set; }

        public PartialPaymentV2()
        {
            flags = PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert one currency to another, possibly taking arbitrage opportunities.
    /// The Amount and SendMax cannot both be XRP.
    /// Also called a circular payment because it delivers money to the sender. This type of transaction may be classified as an "exchange" and not a "payment".
    /// </summary>
    public sealed class CurrencyConversionV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required CurrencyAmount DeliverMax { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>
        /// Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public required CurrencyAmount SendMax { get; set; }

        /// <summary>
        /// Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[] Paths { get; set; }
    }

    /// <summary>
    /// Send MPTs to a holder.
    /// </summary>
    public sealed class MPTPaymentV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public required MPTAmount DeliverMax { get; set; }
    }

    #endregion API V2 Payments

    /// <summary>
    /// Represents the flags of a <see cref="Payment"/> transaction
    /// </summary>
    public enum PaymentFlags : uint
    {
        /// <summary>
        /// If the RequireFullyCanonicalSig amendment is not enabled, this flag enforces a fully-canonical signature
        /// </summary>
        [Obsolete("No effect")]
        tfFullyCanonicalSig = 0x80000000,

        /// <summary>
        /// This flag is only used if a transaction is an inner transaction in a Batch transaction.
        /// This signifies that the transaction isn't signed. Any normal transaction that includes this flag is rejected.
        /// </summary>
        tfInnerBatchTxn = 0x40000000,

        /// <summary>
        /// Do not use the default path; only use paths included in the Paths field. This is intended to force the transaction to take arbitrage opportunities. Most clients do not need this.
        /// </summary>
        tfNoRippleDirect = 0x00010000,

        /// <summary>
        /// If the specified Amount cannot be sent without spending more than SendMax, reduce the received amount instead of failing outright. See Partial Payments for more details.
        /// </summary>
        tfPartialPayment = 0x00020000,

        /// <summary>
        /// Only take paths where all the conversions have an input:output ratio that is equal or better than the ratio of Amount:SendMax.
        /// </summary>
        tfLimitQuality = 0x00040000
    }
}