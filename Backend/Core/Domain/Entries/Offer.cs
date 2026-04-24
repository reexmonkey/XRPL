using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// The Offer ledger entry describes an Offer to exchange currencies in the XRP Ledger's decentralized exchange. (In finance, this is more traditionally known as an order.)
    /// <para/>
    /// An OfferCreate transaction only creates an Offer entry in the ledger when the Offer cannot be fully executed immediately by consuming other Offers already in the ledger. An Offer can become
    /// unfunded through other activities in the network, while remaining in the ledger. When processing transactions, the network automatically removes any unfunded Offers that those transactions
    /// come across. (Otherwise, unfunded Offers remain, because only transactions can change the ledger state.)
    /// </summary>
    /// <typeparam name="TPays">The type of amount and currency requested by the offer creator.</typeparam>
    /// <typeparam name="TGets">The type of amount and currency provided by the offer creator.</typeparam>
    public class Offer : LedgerEntry
    {
        private OfferFlags flags;

        /// <summary>
        /// The address of the account that owns this Offer.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// A list of additional offer directories that link to this offer.
        /// This field is only present if this is a hybrid offer in a permissioned DEX.
        /// The array always contains exactly 1 entry.
        /// </summary>
        public string[]? AdditionalBooks { get; set; }

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
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The Sequence value of the OfferCreate transaction that created this offer. Used in combination with the Account to identify this offer.
        /// </summary>
        public uint Sequence { get; set; }

        /// <summary>
        /// The remaining amount and type of currency (XRP, <see cref="TokenAmount"/>, or <see cref="MPTAmount"/>) requested by the Offer creator.
        /// </summary>
        public required CurrencyAmount TakerPays { get; set; }

        /// <summary>
        /// The remaining amount and type of currency (XRP, <see cref="TokenAmount"/>, or <see cref="MPTAmount"/>) being provided by the Offer creator.
        /// </summary>
        public required CurrencyAmount TakerGets { get; set; }

        /// <summary>
        /// Set of bit-flags for this ledger entry.
        /// </summary>
        public required override uint Flags { get => (uint)flags; set => flags = (OfferFlags)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offer"/> class.
        /// </summary>
        public Offer() => LedgerEntryType = nameof(Offer);
    }

    /// <summary>
    /// Represents the flags for an Offer.
    /// </summary>
    [Flags]
    public enum OfferFlags : uint
    {
        /// <summary>
        /// The offer was placed as passive. This has no effect after the offer is placed into the led
        /// </summary>
        lsfPassive = 0x00010000,

        /// <summary>
        /// The offer was placed as a sell offer. This has no effect after the offer is placed in the ledger, because tfSell only matters if you get a better rate than you asked for, which can only
        /// happen when the offer is initially placed.
        /// </summary>
        lsfSell = 0x00020000,

        /// <summary>
        /// The offer was placed as a hybrid offer, which means it is listed in a permissioned DEX and the open DEX.
        /// </summary>
        lsfHybrid = 0x00040000
    }

    [JsonSerializable(typeof(Offer))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class OfferContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// Represents metadata associated with an <see cref="Offer"/> ledger entry.
    /// </summary>
    public class OfferMeta : LedgerEntryMeta
    {
        /// <summary>
        /// The address of the account that owns this Offer.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// A list of additional offer directories that link to this offer.
        /// This field is only present if this is a hybrid offer in a permissioned DEX.
        /// The array always contains exactly 1 entry.
        /// </summary>
        public string[]? AdditionalBooks { get; set; }

        /// <summary>
        /// The ID of the Offer Directory that links to this Offer.
        /// </summary>
        public string? BookDirectory { get; set; }

        /// <summary>
        /// A hint indicating which page of the offer directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? BookNode { get; set; }

        /// <summary>
        /// Indicates the time after which this Offer is considered unfunded. See Specifying Time for details.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }

        /// <summary>
        /// The Sequence value of the OfferCreate transaction that created this offer. Used in combination with the Account to identify this offer.
        /// </summary>
        public uint? Sequence { get; set; }

        /// <summary>
        /// The remaining amount and type of currency (XRP, <see cref="TokenAmount"/>, or <see cref="MPTAmount"/>) requested by the Offer creator.
        /// </summary>
        public CurrencyAmount? TakerPays { get; set; }

        /// <summary>
        /// The remaining amount and type of currency (XRP, <see cref="TokenAmount"/>, or <see cref="MPTAmount"/>) being provided by the Offer creator.
        /// </summary>
        public CurrencyAmount? TakerGets { get; set; }

        /// <summary>
        /// Numeric amount of the TakerGets currency that the Account sending this OfferCreate transaction has after the execution of all transactions in this ledger.
        /// This does not check whether the currency amount is frozen.
        /// </summary>
        public string? OwnerFunds { get; set; }
    }

    [JsonSerializable(typeof(OfferMeta))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class OfferMetaContext : JsonSerializerContext
    {
    }
}
