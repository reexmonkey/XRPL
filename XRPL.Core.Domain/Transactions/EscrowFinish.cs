using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that delivers XRP from a held payment to the recipient.
    /// <para/> Any account may submit an <see cref="EscrowFinish"/> transaction.
    /// <para/> - If the held payment has a FinishAfter time, you cannot execute it before this time. Specifically, if the corresponding <see cref="EscrowCreate"/> transaction specified a FinishAfter time that is after the close time of the most recently-closed ledger, the EscrowFinish transaction fails.
    /// <para/> - If the held payment has a <see cref="Condition"/>, you cannot execute it unless you provide a matching <see cref="Fulfillment"/> for the condition.
    /// <para/> - You cannot execute a held payment after it has expired. Specifically, if the corresponding <see cref="EscrowCreate"/> transaction specified a CancelAfter time that is before the close time of the most recently-closed ledger, the <see cref="EscrowFinish"/> transaction fails.
    /// </summary>
    [JsonDerivedType(typeof(EscrowFinish), typeDiscriminator: nameof(EscrowFinish))]
    public class EscrowFinish : Transaction
    {
        /// <summary>
        /// Address of the source account that funded the held payment.
        /// </summary>
        public required string Owner { get; set; }

        /// <summary>
        /// Transaction sequence of <see cref="EscrowCreate"/> transaction that created the held payment to finish.
        /// </summary>
        public required uint OfferSequence { get; set; }

        /// <summary>
        /// (Optional) Hex value matching the previously-supplied PREIMAGE-SHA-256 crypto-condition of the held payment.
        /// </summary>
        public string? Condition { get; set; }

        /// <summary>
        /// (Optional) Hex value of the PREIMAGE-SHA-256 crypto-condition fulfillment matching the held payment's <see cref="Condition"/>.
        /// </summary>
        public string? Fulfillment { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EscrowFinish"/> class.
        /// </summary>
        public EscrowFinish() : base(TransactionType.EscrowFinish)
        {
        }
    }
}