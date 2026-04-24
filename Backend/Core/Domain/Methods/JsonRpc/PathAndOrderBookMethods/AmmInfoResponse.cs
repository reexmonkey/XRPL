using System.Text.Json.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.PathAndOrderBookMethods
{
    /// <summary>
    /// Represents a response to an Amm info request.
    /// </summary>
    public record AMMInfoResponse : Response
    {
        /// <summary>
        /// Gets the result of a <see cref="LedgerResponse"/> request.
        /// </summary>
        [JsonPropertyName("result")]
        public required AMMInfoResult Result { get; init; }
    }

    /// <summary>
    /// Represents a result of an <see cref="AMMInfoResponse"/> object.
    /// </summary>
    public abstract record AMMInfoResult : Result
    {
        ///<summary>
        ///An AMM Description Object for the requested asset pair.
        ///</summary>
        [JsonPropertyName("amm")]
        public required AMMDescriptionObject Amm { get; set; }

        ///<summary>
        ///The ledger index of the current in-progress ledger,
        ///which was used when retrieving this information.
        ///</summary>
        [JsonPropertyName("ledger_current_index")]
        public uint? LedgerCurrentIndex { get; set; }

        ///<summary>
        ///The identifying hash of the ledger version that was used when retrieving this data.
        ///</summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        ///<summary>
        ///The ledger index of the ledger version used when retrieving this information.
        ///</summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }

        ///<summary>
        ///If true, the ledger used for this request is validated and these results are final;
        ///if omitted or set to false, the data is pending and may change.
        ///</summary>
        [JsonPropertyName("validated")]
        public required bool Validated { get; set; }
    }

    ///<summary>
    /// Represents the current status of an Automated Market Maker (AMM) in the ledger.
    ///</summary>
    public class AMMDescriptionObject
    {
        ///<summary>
        ///The Address of the AMM Account.
        ///</summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        ///<summary>
        ///The total amount of one asset in the AMM's pool. (Note: This could be asset or asset2 from the request.)
        ///</summary>
        [JsonPropertyName("amount")]
        public required CurrencyAmount Amount { get; set; }

        ///<summary>
        ///The total amount of the other asset in the AMM's pool.
        ///(Note: This could be asset or asset2 from the request.)
        ///</summary>
        [JsonPropertyName("amount2")]
        public required CurrencyAmount Amount2 { get; set; }

        ///<summary>
        ///(Omitted for XRP) If true, the amount currency is currently frozen.
        ///</summary>
        [JsonPropertyName("asset_frozen")]
        public bool? AssetFrozen { get; set; }

        ///<summary>
        ///(Omitted for XRP) If true, the amount2 currency is currently frozen.
        ///</summary>
        [JsonPropertyName("asset2_frozen")]
        public bool? Asset2Frozen { get; set; }

        ///<summary>
        ///(May be omitted) An Auction Slot Object describing the current auction slot holder, if there is one.
        ///</summary>
        [JsonPropertyName("auction_slot")]
        public AMMInfoAuctionSlot? AuctionSlot { get; set; }

        ///<summary>
        ///The total amount of this AMM's LP Tokens outstanding.
        ///If the request specified a liquidity provider in the account field,
        ///instead, this is the amount of this AMM's LP Tokens held by that liquidity provider.
        ///</summary>
        [JsonPropertyName("lp_token")]
        public required CurrencyAmount LPToken { get; set; }

        ///<summary>
        ///The AMM's current trading fee, in units of 1/100,000; a value of 1 is equivalent to a 0.001% fee.
        ///</summary>
        [JsonPropertyName("trading_fee")]
        public required uint TradingFee { get; set; }

        ///<summary>
        /// (May be omitted) The current votes for the AMM's trading fee, as Vote Slot Objects.
        ///</summary>
        [JsonPropertyName("vote_slots")]
        public VoteSlot[]? VoteSlots { get; set; }
    }

    /// <summary>
    /// Represents the current auction slot holder of the AMM.
    /// </summary>
    public class AMMInfoAuctionSlot : AuctionSlot
    {
        ///<summary>
        ///The current 72-minute time interval this auction slot is in, from 0 to 19.
        ///The auction slot expires after 24 hours (20 intervals of 72 minutes) and
        ///affects the cost to outbid the current holder and how much the current holder
        ///is refunded if someone outbids them.
        ///</summary>
        [JsonPropertyName("time_interval")]
        public required uint TimeInterval { get; set; }
    }

    ///<summary>
    /// Represents one liquidity provider's vote to set the trading fee.
    ///</summary>
    public class VoteSlot
    {
        ///<summary>
        ///The Address of this liquidity provider.
        ///</summary>
        [JsonPropertyName("account")]
        public required string Account { get; set; }

        ///<summary>
        ///The trading fee this liquidity provider voted for, in units of 1/100,000.
        ///</summary>
        [JsonPropertyName("trading_fee")]
        public required uint TradingFee { get; set; }

        ///<summary>
        ///How much this liquidity provider's vote counts towards the final trading fee.
        ///This is proportional to how much of the AMM's LP Tokens this liquidity provider holds.
        ///The value is equal to 100,000 times the number of this LP Tokens this liquidity provider holds,
        ///divided by the total number of LP Tokens outstanding. For example, a value of 1000 means that
        ///the liquidity provider holds 1% of this AMM's LP Tokens.
        ///</summary>
        [JsonPropertyName("vote_weight")]
        public required uint VoteWeight { get; set; }
    }
}
