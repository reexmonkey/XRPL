using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a way for tokens to flow through intermediary steps as part of a payment.
    /// <para/>Paths enable cross-currency payments by connecting sender and receiver through orders in the XRP Ledger's decentralized exchange.
    /// Paths also enable complex settlement of offsetting debts.
    /// <para/>A single Payment transaction in the XRP Ledger can use multiple paths,
    /// combining liquidity from different sources to deliver the desired amount.
    /// Thus, a transaction includes a path set, which is a collection of possible paths to take.
    /// All paths in a path set must start with the same currency, and must also end with the same currency as each other.
    /// <para/>Since XRP can be sent directly to any address, an XRP-to-XRP transaction does not use any paths.
    /// </summary>
    [JsonPolymorphic]
    [JsonDerivedType(typeof(AccountPaymentPath), typeDiscriminator: nameof(AccountPaymentPath))]
    [JsonDerivedType(typeof(XrpPaymentPath), typeDiscriminator: nameof(XrpPaymentPath))]
    [JsonDerivedType(typeof(FungibleTokenPaymentPath), typeDiscriminator: nameof(FungibleTokenPaymentPath))]
    public abstract class PaymentPath
    {
        /// <summary>
        /// (Optional) An indicator of which other fields are present.
        /// </summary>
        [Obsolete("DEPRECATED")]
        public int? Type { get; set; }

        /// <summary>
        /// (Optional) A hexadecimal representation of the type field.
        /// </summary>
        [Obsolete("DEPRECATED")]
        public string? TypeHex { get; set; }
    }

    /// <summary>
    /// Represents a way for tokens to flow through the specified intermediary account address as part of a payment.
    /// <para/>Paths enable cross-currency payments by connecting sender and receiver through orders in the XRP Ledger's decentralized exchange.
    /// Paths also enable complex settlement of offsetting debts.
    /// <para/>A single Payment transaction in the XRP Ledger can use multiple paths,
    /// combining liquidity from different sources to deliver the desired amount.
    /// Thus, a transaction includes a path set, which is a collection of possible paths to take.
    /// All paths in a path set must start with the same currency, and must also end with the same currency as each other.
    /// <para/>Since XRP can be sent directly to any address, an XRP-to-XRP transaction does not use any paths.
    /// </summary>
    [JsonDerivedType(typeof(AccountPaymentPath), typeDiscriminator: nameof(AccountPaymentPath))]
    public sealed class AccountPaymentPath : PaymentPath
    {
        /// <summary>
        /// (Optional) If present, this path step represents rippling through the specified address.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }
    }

    /// <summary>
    /// Represents a way for tokens to flow through the specified intermediary changing XRP currency as part of a payment.
    /// <para/>Paths enable cross-currency payments by connecting sender and receiver through orders in the XRP Ledger's decentralized exchange.
    /// Paths also enable complex settlement of offsetting debts.
    /// <para/>A single Payment transaction in the XRP Ledger can use multiple paths,
    /// combining liquidity from different sources to deliver the desired amount.
    /// Thus, a transaction includes a path set, which is a collection of possible paths to take.
    /// All paths in a path set must start with the same currency, and must also end with the same currency as each other.
    /// <para/>Since XRP can be sent directly to any address, an XRP-to-XRP transaction does not use any paths.
    /// </summary>
    [JsonDerivedType(typeof(XrpPaymentPath), typeDiscriminator: nameof(XrpPaymentPath))]
    public sealed class XrpPaymentPath : PaymentPath
    {
        /// <summary>
        /// This path step represents changing XRP through an order book.
        /// <para/>The currency specified indicates the new currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; set; } = "XRP";
    }

    /// <summary>
    /// Represents a way for tokens to flow through the specified intermediary changing currency as part of a payment.
    /// <para/>Paths enable cross-currency payments by connecting sender and receiver through orders in the XRP Ledger's decentralized exchange.
    /// Paths also enable complex settlement of offsetting debts.
    /// <para/>A single Payment transaction in the XRP Ledger can use multiple paths,
    /// combining liquidity from different sources to deliver the desired amount.
    /// Thus, a transaction includes a path set, which is a collection of possible paths to take.
    /// All paths in a path set must start with the same currency, and must also end with the same currency as each other.
    /// <para/>Since XRP can be sent directly to any address, an XRP-to-XRP transaction does not use any paths.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenPaymentPath), typeDiscriminator: nameof(FungibleTokenPaymentPath))]
    public sealed class FungibleTokenPaymentPath : PaymentPath
    {
        /// <summary>
        /// (Optional) If present, this path step represents changing currencies through an order book.
        /// <para/>The currency specified indicates the new currency.
        /// MUST NOT be provided if this step specifies the account field.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        /// <summary>
        /// This path step represents changing currencies and this address defines the issuer of the new currency.
        /// <para/>If omitted in a step with a non-XRP currency, a previous step of the path defines the issuer.
        /// If present when currency is omitted, indicates a path step that uses an order book between same-named currencies with different issuers.
        /// </summary>
        [JsonPropertyName("issuer")]
        public required string Issuer { get; set; }
    }
}
