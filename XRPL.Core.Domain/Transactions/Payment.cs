﻿using XRPL.Core.Domain.Models;

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
    /// <para/>Only applicable to API v1.
    /// </summary>
    public abstract class PaymentV1 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// <para/>For non-XRP amounts, the nested field names MUST be lower-case.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public object Amount { get; set; } = null!;
    }

    /// <summary>
    /// Specifies a a transfer of value from one account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// This transaction type can be used for several types of payments.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v2.
    /// </summary>
    public abstract class PaymentV2 : Payment
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// <para/>For non-XRP amounts, the nested field names MUST be lower-case.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public object DeliverMax { get; set; } = null!;
    }

    #region API V1 Payments

    /// <summary>
    /// Represents a a transfer of value from one XRP account to another.
    /// <para/>Transfers XRP directly from one account to another, using one transaction.
    /// Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class DirectXrpPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// Increases or decreases the amount of a non-XRP currency or asset tracked in the XRP Ledger.
    /// Transfer fees and freezes do not apply when sending and redeeming directly.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class CreateOrRedeemTokensPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpCrossCurrencyPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency in XRP drops to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// Highest amount in XRP drops, this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// Must be supplied for cross-currency/cross-issue payments.
        /// </summary>
        public required string SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenCrossCurrencyPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// Must be supplied for cross-currency/cross-issue payments.
        /// </summary>
        public required TokenAmount SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpPartialPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency in XRP drops to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Minimum amount of XRP drops this transaction should deliver.
        /// </summary>
        public string? DeliverMin { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public string? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="XrpPartialPaymentV1"/> class.
        /// </summary>
        public XrpPartialPaymentV1()
        {
            Flags = (uint)PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenPartialPaymentV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Minimum amount of destination currency this transaction should deliver.
        /// For non-XRP amounts, the nested field names are lower-case.
        /// </summary>
        public TokenAmount? DeliverMin { get; set; }

        /// <summary>
        /// (Optional) Highest amount of source currency, in XRP drops, this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenPartialPaymentV1"/> class.
        /// </summary>
        public FungibleTokenPartialPaymentV1()
        {
            Flags = (uint)PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert XRP to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpCurrencyConversionV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of XRP drops to deliver.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Highest amount of XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public string? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to XRP, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenCurrencyConversionV1 : PaymentV1
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[][] Paths { get; set; }
    }

    #endregion API V1 Payments

    #region API V2 Payments

    /// <summary>
    /// Represents a a transfer of value from one XRP account to another.
    /// <para/>Transfers XRP directly from one account to another, using one transaction.
    /// Always delivers the exact amount. No fee applies other than the basic transaction cost.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class DirectXrpPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public new required string DeliverMax { get => (string)base.DeliverMax; set => base.DeliverMax = value; }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account account to another.
    /// (Depending on the path taken, this can involve additional exchanges of value, which occur atomically.)
    /// Increases or decreases the amount of a non-XRP currency or asset tracked in the XRP Ledger.
    /// Transfer fees and freezes do not apply when sending and redeeming directly.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class CreateOrRedeemTokensPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead..
        /// </summary>
        public new required TokenAmount DeliverMax { get => (TokenAmount)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// For non-XRP amounts, the nested field names MUST be lower-case.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][]? Paths { get; set; }
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpCrossCurrencyPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency in XRP drops to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required string DeliverMax { get => (string)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// Highest amount in XRP drops, this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// Must be supplied for cross-currency/cross-issue payments.
        /// </summary>
        public required string SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to an XRP account.
    /// These payments ripple through the issuer and can take longer paths through several intermediaries if the transaction specifies a path set.
    /// Transfer fees set by the issuer(s) apply to this type of transaction.
    /// These transactions consume offers in the decentralized exchange to connect different currencies,
    /// or currencies with the same currency code and different issuers.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenCrossCurrencyPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required TokenAmount DeliverMax { get => (TokenAmount)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// Must be supplied for cross-currency/cross-issue payments.
        /// </summary>
        public required TokenAmount SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];
    }

    /// <summary>
    /// Represents a a transfer of value from one XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpPartialPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency in XRP drops to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required string DeliverMax { get => (string)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Minimum amount of destination currency this transaction should deliver.
        /// For non-XRP amounts, the nested field names are lower-case.
        /// </summary>
        public string? DeliverMin { get; set; }

        /// <summary>
        /// (Optional) Highest amount in XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public string? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="XrpPartialPaymentV2"/> class.
        /// </summary>
        public XrpPartialPaymentV2()
        {
            Flags = (uint)PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Represents a a transfer of value from one non-XRP account to a non-XRP account.
    /// May include a DeliverMin amount specifying the minimum that the transaction must deliver to be successful;
    /// if the transaction does not specify DeliverMin, it can succeed by delivering any positive amount.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenPartialPaymentV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// If the tfPartialPayment flag is set, deliver up to this amount instead.
        /// </summary>
        public new required TokenAmount DeliverMax { get => (TokenAmount)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Minimum amount of destination currency this transaction should deliver.
        /// For non-XRP amounts, the nested field names are lower-case.
        /// </summary>
        public TokenAmount? DeliverMin { get; set; }

        /// <summary>
        /// (Optional) Highest amount of source currency, in XRP drops, this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public PaymentPath[][] Paths { get; set; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTokenPartialPaymentV2"/> class.
        /// </summary>
        public FungibleTokenPartialPaymentV2()
        {
            Flags = (uint)PaymentFlags.tfPartialPayment;
        }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert XRP to a fungible token, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class XrpCurrencyConversionV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of XRP drops to deliver.
        /// </summary>
        public new required string DeliverMax { get => (string)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Highest amount of XRP drops this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public string? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[][] Paths { get; set; }
    }

    /// <summary>
    /// Consumes offers in the decentralized exchange to convert a fungible token to XRP, possibly taking arbitrage opportunities.
    /// Also called a circular payment because it delivers money to the sender.
    /// This type of transaction may be classified as an "exchange" and not a "payment".
    /// <para/>Payments are also the only way to create accounts.
    /// <para/>Only applicable to API v1.
    /// </summary>
    public class FungibleTokenCurrencyConversionV2 : PaymentV2
    {
        /// <summary>
        /// The maximum amount of currency to deliver.
        /// </summary>
        public new required TokenAmount DeliverMax { get => (TokenAmount)base.DeliverMax; set => base.DeliverMax = value; }

        /// <summary>
        /// (Optional) Highest amount of source currency this transaction is allowed to cost, including transfer fees, exchange rates, and slippage.
        /// <para/>Does not include the XRP destroyed as a cost for submitting the transaction.
        /// </summary>
        public TokenAmount? SendMax { get; set; }

        /// <summary>
        /// (Optional, auto-fillable) Array of payment paths to be used for this transaction.
        /// </summary>
        public required PaymentPath[][] Paths { get; set; }
    }

    #endregion API V2 Payments

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
