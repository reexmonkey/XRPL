using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    public class OracleSet : Transaction
    {
        /// <summary>
        /// The identifying number of the price oracle, which must be unique per owner.
        /// </summary>
        public required string OracleDocumentID { get; set; }

        /// <summary>
        /// An arbitrary value that identifies an oracle provider, such as Chainlink, Band, or DIA.
        /// This field is a string, up to 256 ASCII hex encoded characters (0x20-0x7E).
        /// This field is required when creating a new price oracle, but is optional for updates.
        /// </summary>
        public string Provider { get; set; } = null!;

        /// <summary>
        /// An optional Universal Resource Identifier to reference price data off-chain. This field is limited to 256 bytes.
        /// </summary>
        public string? URI { get; set; }

        /// <summary>
        /// The time the data was last updated, in seconds since the UNIX Epoch. The value must be within 300 seconds (5 minutes) of the ledger's close time.
        /// </summary>
        public uint LastUpdateTime { get; set; }

        /// <summary>
        /// Describes the type of asset, such as "currency", "commodity", or "index".
        /// This field is a string, up to 16 ASCII hex encoded characters (0x20-0x7E).
        /// This field is required when creating a new Oracle ledger entry, but is optional for updates.
        /// </summary>
        public AssetClass AssetClass { get; set; }

        /// <summary>
        /// An array of up to 10 <see cref="PriceData"/> objects, each representing the price information for a token pair.
        /// <para/>More than five PriceData objects require two owner reserves.
        /// </summary>
        public required PriceData[] PriceDataSeries { get; set; }

        public OracleSet() : base(TransactionType.OracleSet)
        {
        }
    }

    public record PriceData
    {
        /// <summary>
        /// The primary asset in a trading pair.
        /// Any valid identifier, such as a stock symbol, bond CUSIP, or currency code is allowed.
        /// For example, in the BTC/USD pair, BTC is the base asset;
        /// in 912810RR9/BTC, 912810RR9 is the base asset.
        /// </summary>
        public required string BaseAsset { get; init; }

        /// <summary>
        /// The quote asset in a trading pair.
        /// The quote asset denotes the price of one unit of the base asset.
        /// For example, in the BTC/USD pair, BTC is the base asset; in 912810RR9/BTC, 912810RR9 is the base asset.
        /// </summary>
        public required string QuoteAsset { get; init; }

        /// <summary>
        /// The asset price after applying the Scale precision level.
        /// It's not included if the last update transaction didn't include the BaseAsset/QuoteAsset pair.
        /// It's recommended you provide this value as a hexadecimal, but client libraries will accept decimal numbers and convert to hexadecimal strings.
        /// </summary>
        public ulong? AssetPrice { get; init; }

        /// <summary>
        /// The scaling factor to apply to an asset price.
        /// For example, if Scale is 6 and original price is 0.155, then the scaled price is 155000.
        /// Valid scale ranges are 0-10. It's not included if the last update transaction didn't include the BaseAsset/QuoteAsset pair.
        /// </summary>
        public byte? Scale { get; init; }
    }
}