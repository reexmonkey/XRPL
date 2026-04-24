namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that removes a credential from the ledger, effectively revoking it.
    /// <para/>Users may also want to delete an unwanted credential to reduce their reserve requirement.
    /// <para/>Remove a credential from the ledger, effectively revoking it. Users may also want to delete an unwanted credential to reduce their reserve requirement.
    /// <para/>This transaction looks for a Credential ledger entry with the specified subject, issuer, and credential type,
    /// and deletes that entry if the sender of the transaction has permission to.
    /// The holder or issuer of a credential can delete it at any time. If the credential is expired, anyone can delete it.
    /// </summary>
    public class CredentialDelete : Transaction
    {
        /// <summary>
        /// Arbitrary data defining the type of credential to delete. The minimum length is 1 byte and the maximum length is 256 bytes.
        /// </summary>
        public required string CredentialType { get; set; }

        /// <summary>
        /// The subject of the credential to delete. If omitted, use the Account (sender of the transaction) as the subject of the credential.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// The issuer of the credential to delete. If omitted, use the Account (sender of the transaction) as the issuer of the credential.
        /// </summary>
        public string? Issuer { get; set; }

        public CredentialDelete() : base(TransactionType.CredentialDelete)
        {
        }
    }
}