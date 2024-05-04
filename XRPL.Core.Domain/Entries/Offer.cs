using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// The Offer ledger entry describes an Offer to exchange currencies in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an Offer entry in the ledger
    /// when the Offer cannot be fully executed immediately by consuming other Offers already in the ledger.
    /// An Offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded Offers that those transactions come across.
    /// (Otherwise, unfunded Offers remain, because only transactions can change the ledger state.)
    /// </summary>
    /// <typeparam name="TPays">The type of amount and token requested by the offer creator.</typeparam>
    /// <typeparam name="TGets">The type of amount and token provided by the offer creator.</typeparam>
    public abstract class Offer : LedgerEntryBase
    {
        protected OfferFlags flags;

        /// <summary>
        /// The address of the account that owns this Offer.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public override required uint Flags { get => (uint)flags; set => flags = (OfferFlags)value; }

        /// <summary>
        /// The ID of the Offer Directory that links to this Offer.
        /// </summary>
        public required string BookDirectory { get; set; }

        /// <summary>
        /// A hint indicating which page of the offer directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string BookNode { get; set; }

        /// <summary>
        /// Indicates the time after which this Offer is considered unfunded. See Specifying Time for details.
        /// </summary>
        public uint Expiration { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this entry.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Sequence value of the OfferCreate transaction that created this offer. Used in combination with the Account to identify this offer.
        /// </summary>
        public required uint Sequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        protected Offer()
        {
            LedgerEntryType = "Offer";
        }
    }

    /// <summary>
    /// The Offer ledger entry describes an Offer to exchange currencies in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an Offer entry in the ledger
    /// when the Offer cannot be fully executed immediately by consuming other Offers already in the ledger.
    /// An Offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded Offers that those transactions come across.
    /// (Otherwise, unfunded Offers remain, because only transactions can change the ledger state.)
    /// </summary>
    /// <typeparam name="TPays">The type of amount and token requested by the offer creator.</typeparam>
    /// <typeparam name="TGets">The type of amount and token provided by the offer creator.</typeparam>
    public abstract class Offer<TPays, TGets> : Offer
        where TPays : class
        where TGets : class
    {
        /// <summary>
        /// The remaining amount and type of token requested by the offer creator.
        /// </summary>
        public required TPays TakerPays { get; set; }

        /// <summary>
        /// The remaining amount and type of token being provided by the Offer creator.
        /// </summary>
        public required TGets TakerGets { get; set; }
    }

    /// <summary>
    /// Represents the flags for an Offer.
    /// </summary>
    [Flags]
    public enum OfferFlags : uint
    {
        lsfPassive = 0x00010000,
        lsfSell = 0x00020000
    }

    /// <summary>
    /// A ledger entry type that describes an offer to request XRP for a token in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an offer entry in the ledger
    /// when the offer cannot be fully executed immediately by consuming other offers already in the ledger.
    /// An offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded offers that those transactions come across.
    /// (Otherwise, unfunded offers remain, because only transactions can change the ledger state.)
    /// </summary>
    public sealed class XrpForFungibleTokenOffer : Offer<string, FungibleToken>
    {
    }

    /// <summary>
    /// A ledger entry type that describes an offer to request a token for XRP in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an offer entry in the ledger
    /// when the offer cannot be fully executed immediately by consuming other offers already in the ledger.
    /// An offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded offers that those transactions come across.
    /// (Otherwise, unfunded offers remain, because only transactions can change the ledger state.)
    /// </summary>
    public sealed class FungibleTokenForXrpOffer : Offer<FungibleToken, string>
    {
    }

    /// <summary>
    /// A ledger entry type that describes an offer to request a token for another token in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an offer entry in the ledger
    /// when the offer cannot be fully executed immediately by consuming other offers already in the ledger.
    /// An offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded offers that those transactions come across.
    /// (Otherwise, unfunded offers remain, because only transactions can change the ledger state.)
    /// </summary>
    public sealed class FungibleTokenOffer : Offer<FungibleToken, FungibleToken>
    {
    }
}