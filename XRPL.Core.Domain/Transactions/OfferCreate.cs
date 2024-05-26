using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that places an <see cref="Offer"/> in the decentralized exchange.
    /// </summary>
    public abstract class OfferCreate : Transaction
    {
        /// <summary>
        /// (Optional) Time after which the <see cref="Offer"/> is no longer active, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// (Optional) An <see cref="Offer"/> to delete first, specified in the same way as OfferCancel.
        /// </summary>
        public uint? OfferSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferCreate"/> class.
        /// </summary>
        public OfferCreate() : base(TransactionType.OfferCreate)
        {
        }
    }

    /// <summary>
    /// Specifies a transaction that places an <see cref="Offer"/> in the decentralized exchange.
    /// </summary>
    public abstract class OfferCreate<TTakerGets, TTakerPays> : OfferCreate
        where TTakerGets : class
        where TTakerPays : class
    {
        /// <summary>
        /// The amount and type of currency being sold.
        /// </summary>
        public required TTakerGets TakerGets { get; set; }

        /// <summary>
        /// The amount and type of currency being bought.
        /// </summary>
        public required TTakerPays TakerPays { get; set; }
    }

    /// <summary>
    /// Represents a transaction that places an <see cref="Offer"/> to sell XRP for fungible tokens in the decentralized exchange.
    /// </summary>
    public sealed class XrpForFungibleTokenOfferCreate : OfferCreate<string, TokenAmount>
    {
    }

    /// <summary>
    /// Represents a transaction that places an <see cref="Offer"/> to sell fungible tokens for XRP in the decentralized exchange.
    /// </summary>
    public sealed class FungibleTokenXrpOfferCreate : OfferCreate<TokenAmount, string>
    {
    }

    /// <summary>
    /// Represents a transaction that places an <see cref="Offer"/> to sell fungible tokens for other types of fungible tokens in the decentralized exchange.
    /// </summary>
    public sealed class FungibleTokenOfferCreate : OfferCreate<TokenAmount, TokenAmount>
    {
    }
}