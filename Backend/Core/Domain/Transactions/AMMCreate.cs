using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that creates a new Automated Market Maker (AMM) instance for trading a pair of assets (XRP/fungible token).
    /// <para/>Creates both an AMM entry and a special <see cref="AccountRoot"/> entry to represent the AMM.
    /// Also transfers ownership of the starting balance of both assets from the sender to the created <see cref="AccountRoot"/>
    /// and issues an initial balance of liquidity provider tokens (LP Tokens) from the AMM account to the sender.
    /// <para/>Caution: When you create the AMM, you should fund it with (approximately) equal-value amounts of each asset.
    /// Otherwise, other users can profit at your expense by trading with this AMM (performing arbitrage).
    /// The currency risk that liquidity providers take on increases with the volatility (potential for imbalance) of the asset pair.
    /// The higher the trading fee, the more it offsets this risk, so it's best to set the trading fee based on the volatility of the asset pair.
    /// <para/>One or both of Amount and Amount2 can be tokens; at most one of them can be XRP. They cannot both have the same currency code and issuer.
    /// <para/>The tokens' issuers must have Default Ripple enabled.
    /// If the Clawback amendment is enabled, those issuers must not have enabled the Allow Clawback flag.
    /// The assets cannot be LP tokens for another AMM.
    /// </summary>
    public class AMMCreate : Transaction
    {
        /// <summary>
        /// The first of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public required CurrencyAmount Amount { get; set; }

        /// <summary>
        /// The second of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public required CurrencyAmount Amount2 { get; set; }

        /// <summary>
        /// The fee to charge for trades against this AMM instance, in units of 1/100,000; a value of 1 is equivalent to 0.001%.
        /// The maximum value is 1000, indicating a 1% fee. The minimum value is 0.
        /// </summary>
        public required ushort TradingFee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMCreate"/> class.
        /// </summary>
        public AMMCreate() : base(TransactionType.AMMCreate)
        {
        }
    }

    [JsonSerializable(typeof(AMMCreate))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class AMMCreateContext : JsonSerializerContext;
}