using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.AccountMethods.AccountNFTs
{
    /// <summary>
    /// Represents a response that encapsulates a list of NFToken objects for a specified account
    /// </summary>

    public class AccountNFTsResponse : ResponseBase<AccountNFTsResult>
    {
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountNFTsResponse"/> object.
    /// </summary>

    public class AccountNFTsResult : ResultBase
    {
        /// <summary>
        /// The account that owns the list of NFTs.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        /// <summary>
        /// A list of NFTs owned by the account, formatted as NFT Objects.
        /// </summary>
        [JsonPropertyName("account_nfts")]
        public required NFTObject[] AccountNFTs { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the current in-progress ledger version, which was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }

        /// <summary>
        /// Server-defined value indicating the response is paginated. 
        /// <para/>Pass this to the next call to resume where this call left off. 
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; set; }
    }

    /// <summary>
    /// Represets one <see cref="NFToken"/> object.
    /// </summary>
    public class NFTObject
    {
        /// <summary>
        /// A bit-map of boolean flags enabled for this NFToken. See <see cref="NFTokenFlags"/> for possible values.
        /// </summary>
        public required uint Flags { get; set; }

        /// <summary>
        /// The account that issued this <see cref="NFToken"/>.
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// The unique identifier of this <see cref="NFToken"/>, in hexadecimal.
        /// </summary>
        public required string NFTokenID { get; set; }

        /// <summary>
        /// The unscrambled version of this token's taxon.
        /// <para/>Several tokens with the same taxon might represent instances of a limited series.
        /// </summary>
        public required uint NFTokenTaxon { get; set; }

        /// <summary>
        /// The URI data associated with this NFToken, in hexadecimal.
        /// </summary>
        public required string URI { get; set; }

        /// <summary>
        /// The token sequence number of this NFToken, which is unique for its issuer.
        /// </summary>
        [JsonPropertyName("nft_serial")]
        public required uint NFTSerial { get; set; }
    }
}