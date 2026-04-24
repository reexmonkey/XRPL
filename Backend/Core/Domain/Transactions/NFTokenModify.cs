namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that modifies the URI field of an existing non-fungible token (NFT).
    /// <para/>Only the issuer, or their authorized minter, can modify an NFT, and only if it was minted with the Mutable flag enabled.
    /// </summary>
    public class NFTokenModify : Transaction
    {
        /// <summary>
        /// Address of the owner of the NFT. If the Account and Owner are the same address, omit this field.
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// The unique identfier of the NFT to modify
        /// </summary>
        public required string NFTokenID { get; set; }

        /// <summary>
        /// Up to 256 bytes of arbitrary data. In JSON, this should be encoded as a string of hexadecimal.
        /// You can use the xrpl.convertStringToHex utility to convert a URI to its hexadecimal equivalent.
        /// This is intended to be a URI that points to the data or metadata associated with the NFT.
        /// The contents could decode to an HTTP or HTTPS URL, an IPFS URI, a magnet link, immediate data encoded as an RFC 2379 "data" URL, or even an issuer-specific encoding.
        /// The URI is not checked for validity. If you do not specify a URI, the existing URI is deleted.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Initializes a new instance of the NFTokenModify class, representing a transaction to modify a non-fungible token.
        /// </summary>
        public NFTokenModify() : base(TransactionType.NFTokenModify)
        {
        }
    }
}