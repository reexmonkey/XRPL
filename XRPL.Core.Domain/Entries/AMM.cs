using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Entries
{
    /// <summary>
    /// Represents a ledger entry that describes an Automated Market Maker.
    /// </summary>
    public class AMM : LedgerEntryBase
    {
        /// <summary>
        /// The definition for one of the two assets this AMM holds.
        /// <para/>In JSON, this is an object with token and issuer fields.
        /// </summary>
        public required STIssue Asset { get; set; }

        /// <summary>
        /// The definition for the other asset this AMM holds.
        /// <para/>In JSON, this is an object with token and issuer fields.
        /// </summary>
        public required STIssue Asset2 { get; set; }

        /// <summary>
        /// The address of the special account that holds this AMM's assets.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// Details of the current owner of the auction slot, as an Auction Slot object.
        /// </summary>
        public AuctionSlot? AuctionSlot { get; set; }

        /// <summary>
        /// The total outstanding balance of liquidity provider tokens from this AMM instance.
        /// <para/>The holders of these tokens can vote on the AMM's trading fee in proportion to their holdings, or redeem the tokens for a share of the AMM's assets which grows with the trading fees collected.
        /// </summary>
        public required LPTokenAmount LPTokenBalance { get; set; }

        /// <summary>
        /// The percentage fee to be charged for trades against this AMM instance, in units of 1/100,000. The maximum value is 1000, for a 1% fee.
        /// </summary>
        public required uint TradingFee { get; set; }

        /// <summary>
        /// A list of vote objects, representing votes on the pool's trading fee.
        /// </summary>
        public VoteEntry[]? VoteSlots { get; set; }
    }

    /// <summary>
    /// Represents an auction slot.
    /// </summary>
    public class AuctionSlot
    {
        /// <summary>
        /// The current owner of this auction slot.
        /// </summary>
        public virtual required string Account { get; set; }

        /// <summary>
        /// A list of at most 4 additional accounts that are authorized to trade at the discounted fee for this AMM instance.
        /// </summary>
        public virtual AuthAccount[]? AuthAccounts { get; set; }

        /// <summary>
        /// The trading fee to be charged to the auction owner, in the same format as TradingFee. Normally, this is 1/10 of the normal fee for this AMM.
        /// </summary>
        public string DiscountedFee { get; set; } = null!;

        /// <summary>
        /// The amount the auction owner paid to win this slot, in LP Tokens.
        /// </summary>
        public virtual required LPTokenAmount Price { get; set; }

        /// <summary>
        /// The time when this slot expires, in seconds since the Ripple Epoch.
        /// </summary>
        public virtual required string Expiration { get; set; }
    }

    /// <summary>
    /// Represents a vote object.
    /// </summary>
    public class VoteEntry
    {
        /// <summary>
        /// The account that cast the vote.
        /// </summary>
        public required string Account { get; set; }

        /// <summary>
        /// The proposed trading fee, in units of 1/100,000; a value of 1 is equivalent to 0.001%. The maximum value is 1000, indicating a 1% fee.
        /// </summary>
        public required ushort TradingFee { get; set; }

        /// <summary>
        /// The weight of the vote, in units of 1/100,000. For example, a value of 1234 means this vote counts as 1.234% of the weighted total vote.
        /// <para/>The weight is determined by the percentage of this AMM's LP Tokens the account owns.
        /// The maximum value is 100000.
        /// </summary>
        public required uint VoteWeight { get; set; }
    }

}
