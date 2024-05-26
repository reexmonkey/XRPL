using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that creates or modifies a trust line linking two accounts.
    /// </summary>
    public class XChainAccountCreateCommit : Transaction
    {
        /// <summary>
        /// The amount, in XRP, to use for account creation.
        /// <para/>This must be greater than or equal to the MinAccountCreateAmount specified in the Bridge ledger object.
        /// </summary>
        public required string Amount { get; set; }

        /// <summary>
        /// The destination account on the destination chain.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// The amount, in XRP, to be used to reward the witness servers for providing signatures.
        /// This must match the amount on the Bridge ledger object.
        /// </summary>
        public string? SignatureReward { get; set; }

        /// <summary>
        /// The bridge to create accounts for.
        /// </summary>
        public required XChainBridge XChainBridge { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XChainAccountCreateCommit"/> class.
        /// </summary>
        public XChainAccountCreateCommit() : base(TransactionType.XChainAccountCreateCommit)
        {
        }
    }
}