namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents the type of cryptographic key.
    /// </summary>
    public enum KeyType
    {
        /// <summary>
        /// Parameters of elliptic curve cryptography used by bitcoin
        /// </summary>
        secp256k1,

        /// <summary>
        /// Elliptic curve signing algorithm using EdDSA and Curve25519
        /// </summary>
        ed25519
    }
}