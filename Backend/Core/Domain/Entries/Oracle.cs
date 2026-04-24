namespace XRPL.Core.Domain.Entries
{
    public class Oracle : LedgerEntry
    {
        /// <summary>
        /// The account with update and delete privileges for the oracle. It's recommended to set up multi-signing on this account.
        /// </summary>
        public required string Owner { get; set; }

        /// <summary>
        /// An arbitrary value that identifies an oracle provider, such as Chainlink, Band, or DIA. This field is a string, up to 256 ASCII hex encoded characters (0x20-0x7E).
        /// </summary>
        public required string Provider { get; set; }

        /// <summary>
        /// An array of up to 10 PriceData objects, each representing the price information for an asset pair. More than five PriceData objects require two owner reserves.
        /// </summary>
        public required PriceData[] PriceDataSeries { get; set; }

        /// <summary>
        /// The time the data was last updated, represented in Unix time. (Note: Unlike many other time values on the XRP Ledger, this value does not use the Ripple Epoch.)
        /// </summary>
        public required uint LastUpdateTime { get; set; }

        /// <summary>
        /// An optional Universal Resource Identifier to reference price data off-chain. This field is limited to 256 bytes.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Arbitrary string to describe the type of asset, such as currency, commodity, or index.
        /// Must be formatted as hexadecimal representing ASCII characters (0x20-0x7E), maximum 16 bytes.
        /// </summary>
        public required string AssetClass { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public required string OwnerNode { get; set; }

        /// <summary>
        /// The hash of the previous transaction that modified this entry.
        /// </summary>
        public required string PreviousTxnID { get; set; }

        /// <summary>
        /// The ledger index that this object was most recently modified or created in.
        /// </summary>
        public required uint PreviousTxnLgrSeq { get; set; }

        public Oracle() => LedgerEntryType = nameof(Oracle);
    }

    public record PriceData
    {
        /// <summary>
        /// The primary asset in a trading pair. Any valid identifier, such as a stock symbol, bond CUSIP, or currency code is allowed.
        /// </summary>
        public required string BaseAsset { get; init; }

        /// <summary>
        /// The quote asset in a trading pair. The quote asset denotes the price of one unit of the base asset.
        /// </summary>
        public required string QuoteAsset { get; init; }

        /// <summary>
        /// The asset price after applying the Scale precision level.
        /// It's not included if the last update transaction didn't include the BaseAsset/QuoteAsset pair.
        /// Displayed in hexadecimal format.
        /// </summary>
        public string? AssetPrice { get; init; }

        /// <summary>
        /// The scaling factor to apply to an asset price.
        /// For example, if Scale is 6 and original price is 0.155, then the scaled price is 155000.
        /// Valid scale ranges are 0-10.
        /// It's not included if the last update transaction didn't include the BaseAsset/QuoteAsset pair.
        /// </summary>
        public ushort? Scale { get; init; }
    }

    /// <summary>
    /// Represents metadata associated with an <see cref="Oracle"/> ledger entry.
    /// </summary>
    public class OracleMeta : LedgerEntryMeta
    {
        /// <summary>
        /// The account with update and delete privileges for the oracle.
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// An arbitrary value that identifies an oracle provider, such as Chainlink, Band, or DIA. This field is a string, up to 256 ASCII hex encoded characters (0x20-0x7E).
        /// </summary>
        public string? Provider { get; set; }

        /// <summary>
        /// An array of up to 10 PriceData objects, each representing the price information for an asset pair. More than five PriceData objects require two owner reserves.
        /// </summary>
        public PriceData[]? PriceDataSeries { get; set; }

        /// <summary>
        /// The time the data was last updated, represented in Unix time.
        /// </summary>
        public uint? LastUpdateTime { get; set; }

        /// <summary>
        /// An optional Universal Resource Identifier to reference price data off-chain. This field is limited to 256 bytes.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// Arbitrary string to describe the type of asset, such as currency, commodity, or index.
        /// Must be formatted as hexadecimal representing ASCII characters (0x20-0x7E), maximum 16 bytes.
        /// </summary>
        public string? AssetClass { get; set; }

        /// <summary>
        /// A hint indicating which page of the owner directory links to this entry, in case the directory consists of multiple pages.
        /// </summary>
        public string? OwnerNode { get; set; }
    }
}
