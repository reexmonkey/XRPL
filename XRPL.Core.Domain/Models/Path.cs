using System.Runtime.Serialization;

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
    [DataContract]
    public class Path
    {
        /// <summary>
        /// (Optional) If present, this path step represents rippling through the specified address. 
        /// <para/>MUST NOT be provided if this step specifies the currency or issuer fields.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// (Optional) If present, this path step represents changing currencies through an order book. 
        /// <para/>The currency specified indicates the new currency. 
        /// MUST NOT be provided if this step specifies the account field.
        /// </summary>
        [DataMember(Name = "currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// (Optional) If present, this path step represents changing currencies and this address defines the issuer of the new currency. 
        /// <para/>If omitted in a step with a non-XRP currency, a previous step of the path defines the issuer. 
        /// If present when currency is omitted, indicates a path step that uses an order book between same-named currencies with different issuers. 
        /// MUST be omitted if the currency is XRP. 
        /// MUST NOT be provided if this step specifies the account field.
        /// </summary>
        [DataMember(Name = "issuer")]
        public string? Issuer { get; set; }
    }
}
