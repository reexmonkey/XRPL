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
    [JsonPolymorphic]
    [JsonDerivedType(typeof(AMMCreate), typeDiscriminator: nameof(AMMCreate))]
    [JsonDerivedType(typeof(XrpFungibleTokenAMMCreate), typeDiscriminator: nameof(XrpFungibleTokenAMMCreate))]
    [JsonDerivedType(typeof(FungibleTokenXrpAMMCreate), typeDiscriminator: nameof(FungibleTokenXrpAMMCreate))]
    [JsonDerivedType(typeof(FungibleTokenAMMCreate), typeDiscriminator: nameof(FungibleTokenAMMCreate))]
    public abstract class AMMCreate : Transaction
    {
        /// <summary>
        /// The first of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public object Amount { get; set; } = null!;

        /// <summary>
        /// The second of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public object Amount2 { get; set; } = null!;

        /// <summary>
        /// The fee to charge for trades against this AMM instance, in units of 1/100,000; a value of 1 is equivalent to 0.001%.
        /// The maximum value is 1000, indicating a 1% fee. The minimum value is 0.
        /// </summary>
        public required uint TradingFee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMCreate"/> class.
        /// </summary>
        protected AMMCreate() : base(TransactionType.AMMCreate)
        {
        }
    }

    /// <summary>
    /// Represents a transaction that creates a new Automated Market Maker (AMM) instance for trading a pair of assets (XRP/fungible token).
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
    [JsonDerivedType(typeof(XrpFungibleTokenAMMCreate), typeDiscriminator: nameof(XrpFungibleTokenAMMCreate))]
    public sealed class XrpFungibleTokenAMMCreate : AMMCreate
    {
        /// <summary>
        /// The first of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required string Amount { get => (string)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The second of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required TokenAmount Amount2 { get => (TokenAmount)base.Amount2; set => base.Amount2 = value; }
    }

    /// <summary>
    /// Represents a transaction that creates a new Automated Market Maker (AMM) instance for trading a pair of assets (fungible token/XRP).
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
    [JsonDerivedType(typeof(FungibleTokenXrpAMMCreate), typeDiscriminator: nameof(FungibleTokenXrpAMMCreate))]
    public sealed class FungibleTokenXrpAMMCreate : AMMCreate
    {
        /// <summary>
        /// The first of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The second of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required string Amount2 { get => (string)base.Amount2; set => base.Amount2 = value; }
    }

    /// <summary>
    /// Specifies a transaction that creates a new Automated Market Maker (AMM) instance for trading a pair of assets (fungible token/fungible token).
    /// <para/>Creates both an AMM entry and a special <see cref="AccountRoot"/> entry to represent the AMM. Also transfers ownership of the starting balance of both assets from the sender to the created <see cref="AccountRoot"/> and issues an initial balance of liquidity provider tokens (LP Tokens) from the AMM account to the sender.
    /// <para/>Caution: When you create the AMM, you should fund it with (approximately) equal-value amounts of each asset. Otherwise, other users can profit at your expense by trading with this AMM (performing arbitrage). The currency risk that liquidity providers take on increases with the volatility (potential for imbalance) of the asset pair. The higher the trading fee, the more it offsets this risk, so it's best to set the trading fee based on the volatility of the asset pair.
    /// <para/>Amount and Amount2 cannot both have the same currency code and issuer.
    /// <para/>The tokens' issuers must have Default Ripple enabled. If the Clawback amendment is enabled, those issuers must not have enabled the Allow Clawback flag. The assets cannot be LP tokens for another AMM.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAMMCreate), typeDiscriminator: nameof(FungibleTokenAMMCreate))]
    public sealed class FungibleTokenAMMCreate : AMMCreate
    {
        /// <summary>
        /// The first of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required TokenAmount Amount { get => (TokenAmount)base.Amount; set => base.Amount = value; }

        /// <summary>
        /// The second of the two assets to fund this AMM with.
        /// <para/>This must be a positive amount.
        /// </summary>
        public new required TokenAmount Amount2 { get => (TokenAmount)base.Amount2; set => base.Amount2 = value; }
    }
}
