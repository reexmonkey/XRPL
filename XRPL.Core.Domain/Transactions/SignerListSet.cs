using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that creates, replaces, or removes a list of signers that can be used to multi-sign a transaction.
    /// <para/>This transaction type was introduced by the MultiSign amendment.
    /// </summary>
    public class SignerListSet : Transaction
    {
        /// <summary>
        /// A target number for the signer weights.
        /// <para/>A multi-signature from this list is valid only if the sum weights of the signatures provided
        /// is greater than or equal to this value. To delete a signer list, use the value 0.
        /// </summary>
        public required uint SignerQuorum { get; set; }

        /// <summary>
        /// (Omitted when deleting) Array of <see cref="SignerEntry"/> objects, indicating the addresses and weights of signers in this list.
        /// This signer list must have at least 1 member and no more than 32 members.
        /// No address may appear more than once in the list, nor may the Account submitting the transaction appear in the list.
        /// </summary>
        public required SignerEntry[] SignerEntries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetRegularKey"/> class.
        /// </summary>
        public SignerListSet() : base(TransactionType.SetRegularKey)
        {
        }
    }
}