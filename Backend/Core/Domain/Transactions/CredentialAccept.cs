namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that accepts a credential, which makes the credential valid. Only the subject of the credential can do this.
    /// </summary>
    public class CredentialAccept : Transaction
    {
        /// <summary>
        /// The address of the issuer that created the credential.
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// Arbitrary data defining the type of credential. The minimum size is 1 byte and the maximum is 64 bytes.
        /// </summary>
        public required string CredentialType { get; set; }

        /// <summary>
        /// Initializes a new instance of the CredentialAccept class, which represents a transaction type for accepting
        /// credentials.
        /// </summary>
        public CredentialAccept() : base(TransactionType.CredentialAccept)
        {
        }
    }
}