using System.ComponentModel;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a single non-token (NFT). 
    /// <para/>It is not stored on its own, but is contained in a NFTokenPage object alongside other NFToken objects.
    /// </summary>
    public class NFToken
    {
        /// <summary>
        /// Uniquely identifies a token.
        /// </summary>
        public string? NFTokenID { get; set; }

        /// <summary>
        /// The URI field points to the data or metadata associated with the NFToken. 
        /// <para/>This field does not need to be an HTTP or HTTPS URL; it could be an IPFS URI, 
        /// a magnet link, an RFC 2379 "data" URL, or even a totally custom encoding. 
        /// The URI is not checked for validity, but the field is limited to a maximum length of 256 bytes.
        /// </summary>
        public Uri? URI { get; set; }
    }

    /// <summary>
    /// Represents properties or other options associated with the NFToken object.
    /// </summary>
    [Flags]
    public enum NFTokenFlags : uint
    {
        /// <summary>
        /// If enabled, the issuer (or an entity authorized by the issuer) can destroy this NFToken. The object's owner can always do so.
        /// </summary>
        [Description("If enabled, the issuer (or an entity authorized by the issuer) can destroy this NFToken. The object's owner can always do so.")]
        lsfBurnable = 0x0001,

        /// <summary>
        /// If enabled, this NFToken can only be offered or sold for XRP.
        /// </summary>
        [Description("If enabled, this NFToken can only be offered or sold for XRP.")]
        lsfOnlyXRP = 0x0002,

        /// <summary>
        /// If enabled, automatically create trust lines to hold transfer fees. Otherwise, buying or selling this NFToken for a token amount fails if the issuer does not have a trust line for that token.
        /// </summary>
        [Obsolete("If enabled, automatically create trust lines to hold transfer fees. Otherwise, buying or selling this NFToken for a token amount fails if the issuer does not have a trust line for that token.")]
        lsfTrustLine = 0x0004,

        /// <summary>
        /// If enabled, this NFToken can be transferred from one holder to another. Otherwise, it can only be transferred to or from the issuer.
        /// </summary>
        [Description("If enabled, this NFToken can be transferred from one holder to another. Otherwise, it can only be transferred to or from the issuer.")]
        lsfTransferable = 0x0008,

        /// <summary>
        /// This flag is reserved for future use. Attempts to set this flag fail.
        /// </summary>
        [Description("This flag is reserved for future use. Attempts to set this flag fail.")]
        lsfReservedFlag = 0x8000
    }
}