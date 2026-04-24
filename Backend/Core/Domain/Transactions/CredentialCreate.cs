namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that provisionally issues a credential in the ledger.
    /// <para/>The credential is not valid until the subject of the credential accepts it with a <see cref="CredentialAccept"/> transaction.
    /// <para/> The Account field (the sender) of the transaction is the issuer of the credential. It is possible for the issuer and the subject to be the same account.
    /// </summary>
    public class CredentialCreate : Transaction
    {
        /// <summary>
        /// The subject of the credential.
        /// </summary>
        public required string Subject { get; set; }

        /// <summary>
        /// Arbitrary data defining the type of credential this entry represents. The minimum length is 1 byte and the maximum length is 64 bytes.
        /// </summary>
        public required string CredentialType { get; set; }

        /// <summary>
        /// Time after which this credential expires, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// Arbitrary additional data about the credential, such as the URL where users can look up an associated Verifiable Credential document.
        /// If present, the minimum length is 1 byte and the maximum is 256 bytes.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Initializes a new instance of the CredentialCreate class.
        /// </summary>
        public CredentialCreate() : base(TransactionType.CredentialCreate)
        {
        }
    }
}