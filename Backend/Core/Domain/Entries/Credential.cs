namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// A Credential entry represents a credential, which contains an attestation about a subject account from a credential issuer account.
    /// The meaning of the attestation is defined by the issuer.
    /// </summary>
    public class Credential : LedgerEntry
    {
        /// <summary>
        /// Arbitrary data defining the type of credential this entry represents. The minimum length is 1 byte and the maximum length is 64 bytes.
        /// </summary>
        public required string CredentialType { get; set; }

        /// <summary>
        /// Time after which the credential is expired, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// The account that issued this credential.
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// A hint indicating which page of the issuer's directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string IssuerNode { get; set; }

        /// <summary>
        /// The identifying hash of the transaction that most recently modified this object.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The index of the ledger that contains the transaction that most recently modified this object.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        /// <summary>
        /// The account that this credential is for.
        /// </summary>
        public required string Subject { get; set; }

        /// <summary>
        /// A hint indicating which page of the subject's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string SubjectNode { get; set; }

        /// <summary>
        /// Arbitrary additional data about the credential, for example a URL where a W3C-formatted Verifiable Credential can be retrieved.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Initializes a new instance of the Credential class.
        /// </summary>
        public Credential() => LedgerEntryType = nameof(Credential);
    }

    public class CredentialMeta : LedgerEntryMeta
    {
        /// <summary>
        /// Arbitrary data defining the type of credential this entry represents. The minimum length is 1 byte and the maximum length is 64 bytes.
        /// </summary>
        public string? CredentialType { get; set; }

        /// <summary>
        /// Time after which the credential is expired, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// The account that issued this credential.
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// A hint indicating which page of the issuer's directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? IssuerNode { get; set; }

        /// <summary>
        /// The account that this credential is for.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// A hint indicating which page of the subject's owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? SubjectNode { get; set; }

        /// <summary>
        /// Arbitrary additional data about the credential, for example a URL where a W3C-formatted Verifiable Credential can be retrieved.
        /// </summary>
        public string? URI { get; set; }
    }
}
