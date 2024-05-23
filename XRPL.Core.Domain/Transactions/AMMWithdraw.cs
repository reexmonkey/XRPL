using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that withdraws assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    public abstract class AMMWithdraw : Transaction
    {
        protected AMMWithdrawFlags? flags;

        /// <summary>
        /// The definition for one of the assets in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required STIssue Asset { get; set; }

        /// <summary>
        /// The definition for the other asset in the AMM's pool.
        /// <para/>In JSON, this is an object with currency and issuer fields (omit issuer for XRP).
        /// </summary>
        public required STIssue Asset2 { get; set; }

        /// <summary>
        /// (Optional) Set of bit-flags for this transaction.
        /// </summary>
        public override required uint? Flags { get => (uint?)flags; set => flags = (AMMWithdrawFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMWithdraw"/> class.
        /// </summary>
        protected AMMWithdraw() : base(TransactionType.AMMWithdraw)
        {
        }
    }

    /// <summary>
    /// Represents the transaction mode for an <see cref="AMMWithdraw"/>.
    /// </summary>
    [Flags]
    public enum AMMWithdrawFlags
    {
        /// <summary>
        /// Return the specified amount of LP Tokens and receive both assets from the AMM's pool in amounts based on the returned LP Tokens' share of the total LP Tokens issued.
        /// </summary>
        tfLPToken = 0x00010000,

        /// <summary>
        /// Return all of your LP Tokens and receive as much as you can of both assets in the AMM's pool.
        /// </summary>
        tfWithdrawAll = 0x00020000,

        /// <summary>
        /// Withdraw at least the specified amount of one asset, by returning all of your LP Tokens. 
        /// Fails if you can't receive at least the specified amount. 
        /// The specified amount can be 0, meaning the transaction succeeds if it withdraws any positive amount.
        /// </summary>
        tfOneAssetWithdrawAll = 0x00040000,

        /// <summary>
        /// Withdraw exactly the specified amount of one asset, by returning as many LP Tokens as necessary.
        /// </summary>
        tfSingleAsset = 0x00080000,

        /// <summary>
        /// Withdraw both of this AMM's assets, in up to the specified amounts. The actual amounts received maintains the balance of assets in the AMM's pool.
        /// </summary>
        tfTwoAsset = 0x00100000,

        /// <summary>
        /// Withdraw up to the specified amount of one asset, by returning up to the specified amount of LP Tokens.
        /// </summary>
        tfOneAssetLPToken = 0x00200000,

        /// <summary>
        /// Withdraw up to the specified amount of one asset, but pay no more than the specified effective price in LP Tokens per unit of the asset received.
        /// </summary>
        tfLimitLPToken = 0x00400000
    }

    /// <summary>
    /// Specifies a transaction that withdraws assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    /// <typeparam name="TAmount1">The type of the currency amount for the first of the two assets.</typeparam>
    /// <typeparam name="TAmount2">The type of the currency amount for the second of the two assets.</typeparam>
    public abstract class AMMWithdraw<TAmount1, TAmount2> : AMMWithdraw
        where TAmount1 : class
        where TAmount2 : class
    {
        /// <summary>
        /// The amount of one asset to deposit to the AMM.
        /// <para/>If present, this must match the type of one of the assets (tokens or XRP) in the AMM's pool.
        /// </summary>
        public TAmount1? Amount { get; set; }

        /// <summary>
        /// The amount of another asset to add to the AMM.
        /// <para/>If present, this must match the type of the other asset in the AMM's pool and cannot be the same asset as <see cref="AMMWithdraw{TAmount1, TAmount2}.Amount"/>.
        /// </summary>
        public TAmount2? Amount2 { get; set; }

        /// <summary>
        /// The maximum effective price, in the deposit asset, to pay for each LP Token received.
        /// </summary>
        public TAmount1? EPrice { get; set; }

        /// <summary>
        /// How many of the AMM's LP Tokens to buy.
        /// </summary>
        public LPTokenAmount? LPTokenIn { get; set; }
    }

    /// <summary>
    /// Represents a transaction that withdraws XRP and fungible token assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    public sealed class XrpFungibleTokenAMMWithdraw : AMMWithdraw<string, TokenAmount>
    {
    }

    /// <summary>
    /// Represents a transaction that withdraws fungible token assets from an Automated Market Maker (AMM) instance by returning the AMM's liquidity provider tokens (LP Tokens).
    /// </summary>
    public sealed class FungibleTokenAMMWithdraw : AMMWithdraw<TokenAmount, TokenAmount>
    {
    }
}