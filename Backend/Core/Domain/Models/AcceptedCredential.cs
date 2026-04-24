namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a credential that includes information about its issuer and type, used for authentication or
    /// authorization purposes.
    /// </summary>
    /// <remarks>The credential type is specified as a hexadecimal string and is defined by the issuer. This
    /// record can be used to identify or validate entities within a permissioned system, where the issuer determines
    /// the meaning and usage of each credential type.</remarks>
    public record AcceptedCredential
    {
        /// <summary>
        /// The issuer of the credential.
        /// </summary>
        public required string Issuer { get; init; }

        /// <summary>
        /// The type of credential, as hexadecimal. This is an arbitrary value from 1 to 64 bytes that the issuer sets when they issue a credential.
        /// </summary>
        public required string CredentialType { get; init; }
    }
}