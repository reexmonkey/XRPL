using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that places an <see cref="Offer"/> in the decentralized exchange.
    /// </summary>
    public class OfferCreate : Transaction
    {
        private OfferCreateFlags? flags;

        /// <summary>
        /// The ledger entry ID of a permissioned domain. If provided, restrict this offer to the permissioned DEX of that domain.
        /// </summary>
        public string? DomnainID { get; set; }

        /// <summary>
        /// (Optional) Time after which the <see cref="Offer"/> is no longer active, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// (Optional) An <see cref="Offer"/> to delete first, specified in the same way as OfferCancel.
        /// </summary>
        public uint? OfferSequence { get; set; }

        /// <summary>
        /// The amount and type of currency being sold.
        /// </summary>
        public required CurrencyAmount TakerGets { get; set; }

        /// <summary>
        /// The amount and type of currency being bought.
        /// </summary>
        public required CurrencyAmount TakerPays { get; set; }

        public override uint? Flags { get => (uint?)flags; set => flags = (OfferCreateFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferCreate"/> class.
        /// </summary>
        public OfferCreate() : base(TransactionType.OfferCreate)
        {
        }
    }

    /// <summary>
    /// Specifies the available flags for configuring offer creation behavior in the order book.
    /// </summary>
    /// <remarks>OfferCreateFlags enable various order execution strategies, such as passive offers, immediate
    /// or cancel orders, fill or kill orders, and hybrid offers that can interact with both permissioned and open
    /// decentralized exchanges. Some flags impose specific requirements, such as providing a DomainID for hybrid offers
    /// or enforcing fully-canonical signatures. These flags allow developers to tailor offer handling to meet different
    /// trading and ledger requirements.</remarks>
    public enum OfferCreateFlags : uint
    {
        /// <summary>
        /// Do not consume offers that exactly match this one, only offers that cross it.
        /// This makes it possible to set up offers in the ledger that peg the exchange rate at a specific value.
        /// </summary>
        tfPassive = 0x00010000,

        /// <summary>
        /// Treat the offer as an Immediate or Cancel order and do not place an Offer entry into the order books.
        /// The transaction trades as much as it can by consuming existing offers when it's processed.
        /// </summary>
        tfImmediateOrCancel = 0x00020000,

        /// <summary>
        /// Treat the offer as a Fill or Kill order, do not place an Offer entry into the order books, and cancel the offer if it cannot be fully filled at the time of execution.
        /// By default, this means that the owner must receive the full TakerPays amount; if the tfSell flag is enabled, the owner must be able to spend the entire TakerGets amount instead.
        /// </summary>
        tfFillOrKill = 0x00040000,

        /// <summary>
        /// Exchange the entire TakerGets amount, even if it means obtaining more than the TakerPays amount in exchange.
        /// </summary>
        tfSell = 0x00080000,

        /// <summary>
        /// Make this a hybrid offer that can use both a permissioned DEX and the open DEX.
        /// The DomainID field must be provided when using this flag
        /// </summary>
        tfHybrid = 0x00100000,

        /// <summary>
        /// If the RequireFullyCanonicalSig amendment is not enabled, this flag enforces a fully-canonical signature
        /// </summary>
        [Obsolete("No effect")]
        tfFullyCanonicalSig = 0x80000000,

        /// <summary>
        /// This flag is only used if a transaction is an inner transaction in a Batch transaction.
        /// This signifies that the transaction isn't signed. Any normal transaction that includes this flag is rejected.
        /// </summary>
        tfInnerBatchTxn = 0x40000000
    }

    [JsonSerializable(typeof(OfferCreate))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class OfferCreateContext : JsonSerializerContext;
}
