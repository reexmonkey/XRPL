using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.PseudoTransactions
{
    /// <summary>
    /// Represents a pseudo-transaction that marks a change in transaction cost or reserve requirements as a result of Fee Voting.
    /// <para/>Note: You cannot send a pseudo-transaction, but you may find one when processing ledgers.
    /// </summary>
    [JsonDerivedType(typeof(SetFee), typeDiscriminator: nameof(SetFee))]
    public class SetFee : PseudoTransaction
    {
        /// <summary>
        /// The charge, in drops of XRP, for the reference transaction, as hex. (This is the transaction cost before scaling for load.)
        /// </summary>
        public required string BaseFee { get; set; }

        /// <summary>
        /// The cost, in fee units, of the reference transaction
        /// </summary>
        public required uint ReferenceFeeUnits { get; set; }

        /// <summary>
        /// The base reserve, in drops
        /// </summary>
        public required uint ReserveBase { get; set; }

        /// <summary>
        /// The incremental reserve, in drops
        /// </summary>
        public required uint ReserveIncrement { get; set; }

        /// <summary>
        /// (Omitted for some historical SetFee pseudo-transactions) The index of the ledger version where this pseudo-transaction appears. This distinguishes the pseudo-transaction from other occurrences of the same change.
        /// </summary>
        public uint LedgerSequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetFee"/> class.
        /// </summary>
        public SetFee() : base(PseudoTransactionType.SetFee)
        {

        }
    }

    /// <summary>
    /// Represents a pseudo-transaction (when the XRPFees amendment is enabled) that marks a change in transaction cost or reserve requirements as a result of Fee Voting.
    /// <para/>Note: You cannot send a pseudo-transaction, but you may find one when processing ledgers.
    /// </summary>
    [JsonDerivedType(typeof(LastestSetFee), typeDiscriminator: nameof(LastestSetFee))]
    public class LastestSetFee : PseudoTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LastestSetFee"/> class.
        /// </summary>
        public LastestSetFee() : base(PseudoTransactionType.SetFee)
        {
        }

        /// <summary>
        /// The charge, in drops of XRP, for the reference transaction, as hex. (This is the transaction cost before scaling for load.)
        /// </summary>
        public required string BaseFeeDrops { get; set; }

        /// <summary>
        /// The base reserve, in drops
        /// </summary>
        public required uint ReserveBaseDrops { get; set; }

        /// <summary>
        /// The incremental reserve, in drops
        /// </summary>
        public required uint ReserveIncrementDrops { get; set; }

        /// <summary>
        /// (Omitted for some historical SetFee pseudo-transactions) The index of the ledger version where this pseudo-transaction appears. This distinguishes the pseudo-transaction from other occurrences of the same change.
        /// </summary>
        public uint LedgerSequence { get; set; }
    }
}
