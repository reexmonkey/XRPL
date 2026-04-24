namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that sets aside funds in an escrow that delivers them to a predetermined recipient when certain conditions are met.
    /// If the escrow has an expiration, the funds can also be returned to the sender after it expires.
    /// <para/>It is not possible to create a conditional escrow with no expiration, but you can specify an expiration that is very far in the future.
    /// </summary>
    public class EscrowCreate : Transaction
    {
        /// <summary>
        /// Amount of XRP, in drops, to deduct from the sender's balance and escrow.
        /// <para/>Once escrowed, the XRP can either go to the <see cref="Destination"/> address (after the <see cref="FinishAfter"/> time) or returned to the sender (after the <see cref="CancelAfter"/> time).
        /// </summary>
        public override required string Account { get => base.Account; set => base.Account = value; }

        /// <summary>
        /// Address to receive escrowed XRP.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// (Optional) The time, in seconds since the Ripple Epoch, when this escrow expires.
        /// <para/>This value is immutable; the funds can only be returned to the sender after this time.
        /// </summary>
        public uint? CancelAfter { get; set; }

        /// <summary>
        /// (Optional) The time, in seconds since the Ripple Epoch, when the escrowed XRP can be released to the recipient.
        /// <para/>This value is immutable, and the funds can't be accessed until this time.
        /// </summary>
        public uint? FinishAfter { get; set; }

        /// <summary>
        /// (Optional) Hex value representing a PREIMAGE-SHA-256 crypto-condition.
        /// <para/>The funds can only be delivered to the recipient if this condition is fulfilled.
        /// If the condition is not fulfilled before the expiration time specified in the <see cref="CancelAfter"/> field, the XRP can only revert to the sender.
        /// </summary>
        public string? Condition { get; set; }

        /// <summary>
        /// (Optional) Arbitrary tag to further specify the destination for this escrowed payment, such as a hosted recipient at the destination address.
        /// </summary>
        public string? DestinationTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EscrowCreate"/> class.
        /// </summary>
        public EscrowCreate() : base(TransactionType.EscrowCreate)
        {
        }
    }
}