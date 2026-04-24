namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that grants preauthorization to send payments to your account. This is only useful if you are using (or plan to use) Deposit Authorization.
    /// </summary>
    public class DepositPreauth : Transaction
    {
        /// <summary>
        /// (Optional) The XRP Ledger address of the sender to preauthorize.
        /// </summary>
        public string? Authorize { get; set; }

        /// <summary>
        /// A set of credentials to authorize.
        /// </summary>
        public AuthorizeCredential[]? AuthorizeCredentials { get; set; }

        /// <summary>
        /// (Optional) The XRP Ledger address of a sender whose preauthorization should be revoked.
        /// </summary>
        public string? Unauthorize { get; set; }

        /// <summary>
        /// A set of credentials whose preauthorization should be revoked.
        /// </summary>
        public AuthorizeCredential[]? UnauthorizeCredentials { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositPreauth"/> class.
        /// </summary>
        protected DepositPreauth() : base(TransactionType.DepositPreauth)
        {
        }
    }

    /// <summary>
    /// Represents the credentials used for authorization, including the issuer and credential type.
    /// </summary>
    /// <remarks>This record is designed to encapsulate the essential information required for authorization
    /// processes. Ensure that both properties are provided as they are marked as required.</remarks>
    public record AuthorizeCredential
    {
        /// <summary>
        /// The issuer of the credential.
        /// </summary>
        public required string Issuer { get; init; }

        /// <summary>
        /// The credential type of the credential.
        /// </summary>
        public required string CredentialType { get; init; }
    }
}