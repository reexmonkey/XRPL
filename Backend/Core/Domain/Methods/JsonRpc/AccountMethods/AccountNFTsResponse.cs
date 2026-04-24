using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.AccountMethods
{
    /// <summary>
    /// Represents a response that encapsulates a list of NFToken objects for a specified account
    /// </summary>
    public record AccountNFTsResponse : Response
    {
        /// <summary>
        /// The result of the query; contents vary depending on the command.
        /// </summary>
        [JsonPropertyName("result")]
        public required AccountNFTsResult Result { get; set; }
    }

    /// <summary>
    /// Represents the result of an <see cref="AccountNFTsResponse"/> object.
    /// </summary>

    public record AccountNFTsResult : Result
    {
        /// <summary>
        /// The account that owns the list of NFTs.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }

        /// <summary>
        /// A list of NFTs owned by the account, formatted as NFT Objects.
        /// </summary>
        [JsonPropertyName("account_nfts")]
        public required NFTObject[] AccountNFTs { get; init; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; init; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; init; }

        /// <summary>
        /// (May be omitted) The ledger index of the current in-progress ledger version, which was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public uint? LedgerCurrentIndex { get; init; }

        /// <summary>
        /// If included and set to true, the information in this response comes from a validated ledger version.
        /// <para/>Otherwise, the information is subject to change
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; init; }

        /// <summary>
        /// Server-defined value indicating the response is paginated.
        /// <para/>Pass this to the next call to resume where this call left off.
        /// Omitted when there are no additional pages after this one.
        /// </summary>
        [JsonPropertyName("marker")]
        public object? Marker { get; init; }
    }

    /// <summary>
    /// Represets one <see cref="NFToken"/> object.
    /// </summary>
    public record NFTObject
    {
        /// <summary>
        /// A bit-map of boolean flags enabled for this NFToken. See <see cref="NFTokenFlags"/> for possible values.
        /// </summary>
        public required uint Flags { get; init; }

        /// <summary>
        /// The account that issued this <see cref="NFToken"/>.
        /// </summary>
        public required string Issuer { get; init; }

        /// <summary>
        /// The unique identifier of this <see cref="NFToken"/>, in hexadecimal.
        /// </summary>
        public required string NFTokenID { get; init; }

        /// <summary>
        /// The unscrambled version of this token's taxon.
        /// <para/>Several tokens with the same taxon might represent instances of a limited series.
        /// </summary>
        public required uint NFTokenTaxon { get; init; }

        /// <summary>
        /// The URI data associated with this NFToken, in hexadecimal.
        /// </summary>
        public required string URI { get; init; }

        /// <summary>
        /// The token sequence number of this NFToken, which is unique for its issuer.
        /// </summary>
        [JsonPropertyName("nft_serial")]
        public required uint NFTSerial { get; init; }
    }
}
