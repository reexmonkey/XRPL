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
    public abstract class Offer : LedgerEntryBase
    {
        /// <summary>
        /// The address of the account that owns this Offer.
        /// </summary>
        public required string Account { get; set; }

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
        /// The remaining amount and type of token requested by the offer creator.
        /// </summary>
        public object TakerPays { get; set; } = null!;

        /// <summary>
        /// The remaining amount and type of token being provided by the Offer creator.
        /// </summary>
        public object TakerGets { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        protected Offer()
        {
            LedgerEntryType = "Offer";
        }
    }

    /// <summary>
    /// Represents the flags for an Offer.
    /// </summary>
    [Flags]
    public enum OfferFlags : uint
    {
        /// <summary>
        /// The offer was placed as "passive".
        /// <para/>This has no effect after the offer is placed into the ledger.
        /// </summary>
        lsfPassive = 0x00010000,

        /// <summary>
        /// The offer was placed as a "Sell" offer.
        /// <para/>This has no effect after the offer is placed in the ledger, because tfSell only matters if you get a better rate than you asked for, which can only happen when the offer is initially placed.
        /// </summary>
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
    public class XrpForFungibleTokenOffer : Offer
    {
        /// <summary>
        /// The remaining amount of XRP in drops requested by the offer creator.
        /// </summary>
        public new required string TakerPays { get => (string)base.TakerPays; set => base.TakerPays = value; }

        /// <summary>
        /// The remaining amount and type of currency being provided by the Offer creator.
        /// </summary>
        public new required TokenAmount TakerGets { get => (TokenAmount)base.TakerGets; set => base.TakerGets = value; }
    }

    /// <summary>
    /// A ledger entry type that describes an offer to request a fungible token for XRP in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an offer entry in the ledger
    /// when the offer cannot be fully executed immediately by consuming other offers already in the ledger.
    /// An offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded offers that those transactions come across.
    /// (Otherwise, unfunded offers remain, because only transactions can change the ledger state.)
    /// </summary>
    public class FungibleTokenForXrpOffer : Offer
    {
        /// <summary>
        /// The remaining amount and type of currency requested by the offer creator.
        /// </summary>
        public new required TokenAmount TakerPays { get => (TokenAmount)base.TakerPays; set => base.TakerPays = value; }

        /// <summary>
        /// The remaining amount of XRP in drops being provided by the Offer creator.
        /// </summary>
        public new required string TakerGets { get => (string)base.TakerGets; set => base.TakerGets = value; }
    }

    /// <summary>
    /// A ledger entry type that describes an offer to request a fungible token for another fungible token in the XRP Ledger's decentralized exchange.
    /// (In finance, this is more traditionally known as an order.)
    /// <para/>An OfferCreate transaction only creates an offer entry in the ledger
    /// when the offer cannot be fully executed immediately by consuming other offers already in the ledger.
    /// An offer can become unfunded through other activities in the network, while remaining in the ledger.
    /// When processing transactions, the network automatically removes any unfunded offers that those transactions come across.
    /// (Otherwise, unfunded offers remain, because only transactions can change the ledger state.)
    /// </summary>
    public class FungibleTokenOffer : Offer
    {
        /// <summary>
        /// The remaining amount and type of currency requested by the offer creator.
        /// </summary>
        public new required TokenAmount TakerPays { get => (TokenAmount)base.TakerPays; set => base.TakerPays = value; }

        /// <summary>
        /// The remaining amount and type of currency being provided by the Offer creator.
        /// </summary>
        public new required TokenAmount TakerGets { get => (TokenAmount)base.TakerGets; set => base.TakerGets = value; }
    }
}
