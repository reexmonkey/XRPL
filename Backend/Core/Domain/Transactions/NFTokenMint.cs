using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that creates a non-fungible token and adds it to the relevant <see cref="NFTokenPage"/> object of the NFTokenMinter as an <see cref="NFToken"/> object.
    /// <para/>This transaction is the only opportunity the NFTokenMinter has to specify any token fields that are defined as immutable (for example, the TokenFlags).
    /// </summary>
    public class NFTokenMint : Transaction
    {
        /// <summary>
        /// An arbitrary taxon, or shared identifier, for a series or collection of related NFTs.
        /// <para/>To mint a series of NFTs, give them all the same taxon.
        /// </summary>
        public required uint NFTokenTaxon { get; set; }

        /// <summary>
        /// (Optional) The issuer of the token, if the sender of the account is issuing it on behalf of another account.
        /// <para/>This field must be omitted if the account sending the transaction is the issuer of the NFToken. If provided, the issuer's AccountRoot object must have the NFTokenMinter field set to the sender of this transaction (this transaction's Account field).
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// (Optional) The value specifies the fee charged by the issuer for secondary sales of the NFToken, if such sales are allowed.
        /// <para/>Valid values for this field are between 0 and 50000 inclusive, allowing transfer rates of between 0.00% and 50.00% in increments of 0.001. If this field is provided, the transaction MUST have the tfTransferable flag enabled.
        /// </summary>
        public ushort? TransferFee { get; set; }

        /// <summary>
        /// (Optional) Up to 256 bytes of arbitrary data.
        /// <para/>In JSON, this should be encoded as a string of hexadecimal. You can use the xrpl.convertStringToHex utility to convert a URI to its hexadecimal equivalent. This is intended to be a URI that points to the data or metadata associated with the NFT. The contents could decode to an HTTP or HTTPS URL, an IPFS URI, a magnet link, immediate data encoded as an RFC 2379 "data" URL, or even an issuer-specific encoding. The URI is NOT checked for validity
        /// </summary>
        public string? Uri { get; set; }

        /// <summary>
        /// Indicates the amount expected or offered for the corresponding NFToken.
        /// The amount must be non-zero, except where the asset is XRP;
        /// then, it is legal to specify an amount of zero, which means that the current owner of the token is giving it away, gratis,
        /// either to anyone at all, or to the account identified by the Destination field.
        /// </summary>
        public CurrencyAmount? Amount { get; set; }

        /// <summary>
        /// Time after which the offer is no longer active, in seconds since the Ripple Epoch.
        /// Results in an error if the Amount field is not specified.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// If present, indicates that this offer may only be accepted by the specified account.
        /// Attempts by other accounts to accept this offer MUST fail. Results in an error if the Amount field is not specified.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenMint"/> class.
        /// </summary>
        public NFTokenMint() : base(TransactionType.NFTokenMint)
        {
        }
    }

    /// <summary>
    /// Represents flags of the <see cref="NFTokenMint"/> transaction.
    /// </summary>
    [Flags]
    public enum NFTokenMintFlags : uint
    {
        /// <summary>
        /// Allow the issuer (or an entity authorized by the issuer) to destroy the minted NFToken. (The NFToken's owner can always do so.)
        /// </summary>
        tfBurnable = 0x00000001,

        /// <summary>
        /// The minted NFToken can only be bought or sold for XRP. This can be desirable if the token has a transfer fee and the issuer does not want to receive fees in non-XRP currencies.
        /// </summary>
        tfOnlyXRP = 0x00000002,

        /// <summary>
        /// Automatically create trust lines from the issuer to hold transfer fees received from transferring the minted NFToken. The fixRemoveNFTokenAutoTrustLine amendment makes it invalid to set this flag
        /// </summary>
        [Obsolete("DEPRECATED")]
        tfTrustLine = 0x00000004,

        /// <summary>
        /// The minted NFToken can be transferred to others. If this flag is not enabled, the token can still be transferred from or to the issuer, but a transfer to the issuer must be made based on a buy offer from the issuer and not a sell offer from the NFT holder.
        /// </summary>
        tfTransferable = 0x00000008,

        /// <summary>
        /// The URI field of the minted NFToken can be updated using the NFTokenModify transaction.
        /// </summary>
        tfMutable = 0x00000010,

        /// <summary>
        /// If the RequireFullyCanonicalSig amendment is not enabled, this flag enforces a fully-canonical signature
        /// </summary>
        [Obsolete("No effect")]
        tfFullyCanonicalSig = 0x80000000,

        /// <summary>
        /// This flag is only used if a transaction is an inner transaction in a Batch transaction.
        /// This signifies that the transaction isn't signed. Any normal transaction that includes this flag is rejected.
        /// </summary>
        tfInnerBatchTxn = 0x40000000
    }

    [JsonSerializable(typeof(NFTokenMint))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class NFTokenMintContext : JsonSerializerContext;
}