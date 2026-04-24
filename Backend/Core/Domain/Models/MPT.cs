using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents a Multi-Purpose Token (MPT) on the XRP Ledger.
    /// <para/>
    /// Multi-Purpose Tokens (MPTs) are a form of fungible token on the XRP Ledger. They have been designed for greater efficiency and ease of use based on lessons learned from trust line tokens on
    /// the XRP Ledger.
    /// <para/>
    /// MPTs let you take advantage of ready-to-use tokenization features with a few lines of code. You can create many token experiences from one integration, while the code of the XRP Ledger
    /// blockchain does the heavy lifting.
    /// </summary>
    public class MPT
    {
        /// <summary>
        /// The ticker symbol used to represent the token. Must be uppercase letters (A-Z) and digits (0-9) only. A maximum of 6 characters is recommended.
        /// </summary>
        [JsonPropertyName("t")]
        public string Ticker { get; set; } = null!;

        /// <summary>
        /// The display name of the token. Any UTF-8 string is permitted.
        /// </summary>
        [JsonPropertyName("n")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// A short description of the token. Any UTF-8 string is permitted.
        /// </summary>
        [JsonPropertyName("d")]
        public string? Desc { get; set; }

        /// <summary>
        /// The URI to the token icon. Can be hostname/path (HTTPS is assumed), or full URI for other protocols.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = null!;

        /// <summary>
        /// Categorizes tokens by their primary purpose and backing. See <see cref="AssetClass"/> for more details.
        /// </summary>
        [JsonPropertyName("ac")]
        public AssetClass AssetClass { get; set; }

        /// <summary>
        /// An optional subcategory that is only required if the asset class is <see cref="AssetClass.rwa"/>.
        /// </summary>
        [JsonPropertyName("as")]
        public AssetSubclass? AssetSubclass { get; set; }

        /// <summary>
        /// Name of the entity issuing the token. Any UTF-8 string is permitted.
        /// </summary>
        [JsonPropertyName("in")]
        public string IssuerName { get; set; } = null!;

        /// <summary>
        /// The list of related URIs such as website, documentation, and social media.
        /// </summary>
        [JsonPropertyName("uris")]
        public URI[] Uris { get; set; } = null!;

        /// <summary>
        /// Freeform field for key token details like interest rate, maturity date, term, or other relevant info. Any valid JSON object or UTF-8 string is permitted.
        /// </summary>
        [JsonPropertyName("ai")]
        public object AdditionalInfo { get; set; } = null!;
    }

    public enum AssetClass
    {
        /// <summary>
        /// Tokens representing real-world assets (RWAs), which derive value from legally enforceable claims on physical or off-chain financial assets.
        /// </summary>
        rwa,

        /// <summary>
        /// Community-driven tokens without intrinsic backing or utility claims, primarily driven by internet culture or speculation.
        /// </summary>
        memes,

        /// <summary>
        /// Tokens representing assets from other blockchains, typically backed 1:1 by bridges or custodians.
        /// </summary>
        wrapped,

        /// <summary>
        /// Tokens used in games or virtual worlds, often representing in-game currency, assets, or rewards.
        /// </summary>
        gaming,

        /// <summary>
        /// Tokens native to or used within DeFi protocols, including governance tokens, DEX tokens, and lending assets.
        /// </summary>
        defi,

        /// <summary>
        /// Tokens that do not clearly fit into the defined categories. This may include experimental, test, or tokens with unique use cases not covered elsewhere.
        /// </summary>
        other
    }

    /// <summary>
    /// Describes what type of real-world asset (RWA) backs the token and what legal or regulatory framework might apply.
    /// </summary>
    public enum AssetSubclass
    {
        /// <summary>
        /// Tokens pegged to a stable value, typically fiat currencies like USD, which are backed by reserves like cash, treasuries, or crypto collateral.
        /// </summary>
        stablecoin,

        /// <summary>
        /// Tokens that represent physical commodities like gold, silver, or oil, often redeemable or legally linked to off-chain reserves.
        /// </summary>
        commodity,

        /// <summary>
        /// Tokens representing ownership or claims on real estate, including fractionalized property shares or REIT-like instruments.
        /// </summary>
        real_estate,

        /// <summary>
        /// Tokens representing debt obligations from private entities, such as loans, invoices, or receivables.
        /// </summary>
        private_credit,

        /// <summary>
        /// Tokens representing ownership shares in companies, similar to traditional stock or equity instruments.
        /// </summary>
        equity,

        /// <summary>
        /// Tokens backed by government debt instruments, such as U.S. Treasury bills or bonds.
        /// </summary>
        treasury,

        /// <summary>
        /// Tokens that do not fit into the predefined categories, including experimental, hybrid, or emerging real-world asset types.
        /// </summary>
        other
    }

    public record URI
    {
        /// <summary>
        /// The hostname/path or full URI link to the related resource.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;

        /// <summary>
        /// The category of the link provided.
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; init; }

        /// <summary>
        /// Human-readable label for the link.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;
    }

    public enum Category
    {
        website,
        social,
        docs,
        other
    }
}