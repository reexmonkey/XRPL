using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response to an Amm info request.
    /// </summary>
    public class AmmInfoResponse : ResponseBase<AmmInfoResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="AmmInfoResponse"/> object.
    /// </summary>
    [DataContract]
    public abstract class AmmInfoResult : ResultBase
    {
        ///<summary>
        ///An AMM Description Object for the requested asset pair.
        ///</summary>
        [DataMember(Name = "amm")]
        public required AmmDescription Amm {  get; set; }

        ///<summary>
        ///The ledger index of the current in-progress ledger,
        ///which was used when retrieving this information.
        ///</summary>
        [DataMember(Name = "ledger_current_index")]
        public uint? LedgerCurrentIndex { get; set; }

        ///<summary>
        ///The identifying hash of the ledger version that was used when retrieving this data.
        ///</summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        ///<summary>
        ///The ledger index of the ledger version used when retrieving this information.
        ///</summary>
        [DataMember(Name = "ledger_index")]
        public uint? LedgerIndex { get; set;}

        ///<summary>
        ///If true, the ledger used for this request is validated and these results are final;
        ///if omitted or set to false, the data is pending and may change.
        ///</summary>
        [DataMember(Name = "validated")]
        public required bool Validated { get; set; }
    }


    ///<summary>
    ///The amm field is an object describing the current status of an Automated Market Maker (AMM) in the ledger
    ///</summary>
    [DataContract]
    public class AmmDescription
    {
        ///<summary>
        ///The Address of the AMM Account.
        ///</summary>
        [DataMember(Name = "account")]
        public required string Account {  get; set; }

        ///<summary>
        ///The total amount of one asset in the AMM's pool. (Note: This could be asset or asset2 from the request.)
        ///</summary>
        [DataMember(Name = "amount")]
        public required TokenAmount Amount { get; set; }

        ///<summary>
        ///The total amount of the other asset in the AMM's pool.
        ///(Note: This could be asset or asset2 from the request.)
        ///</summary>
        [DataMember(Name = "amount2")]
        public required LPTokenAmount Amount2 { get; set; }

        ///<summary>
        ///(Omitted for XRP) If true, the amount currency is currently frozen.
        ///</summary>
        [DataMember(Name = "asset_frozen")]
        public bool ? AssetFrozen { get; set; }

        ///<summary>
        ///(Omitted for XRP) If true, the amount2 currency is currently frozen.
        ///</summary>
        [DataMember(Name = "asset2_frozen")]
        public bool? Asset2Frozen { get; set; }

        ///<summary>
        ///(May be omitted) An Auction Slot Object describing the current auction slot holder, if there is one.
        ///</summary>
        [DataMember(Name = "auction_slot")]
        public AuctionSlot? AuctionSlot { get; set; }

        ///<summary>
        ///The total amount of this AMM's LP Tokens outstanding.
        ///If the request specified a liquidity provider in the account field,
        ///instead, this is the amount of this AMM's LP Tokens held by that liquidity provider.
        ///</summary>
        [DataMember(Name = "lp_token")]
        public required LPTokenAmount LPToken { get; set; }

        ///<summary>
        ///The AMM's current trading fee, in units of 1/100,000; a value of 1 is equivalent to a 0.001% fee.
        ///</summary>
        [DataMember(Name = "trading_fee")]
        public required uint TradingFee { get; set; }

        ///<summary>
        ///
        ///</summary>
        [DataMember(Name = "vote_slots")]
        public VoteSlot[]? VoteSlots { get; set; }
    }

    ///<Summary>
    ///The auction_slot field of the amm object describes the current auction slot holder of the AMM.
    ///</Summary>>
    [DataContract]
    public class AuctionSlot
    {
        ///<summary>
        ///The Address of the account that owns the auction slot.
        ///</summary>
        [DataMember(Name = "account")]
        public required string Account {  get; set; }

        ///<summary>
        ///
        ///</summary>
        [DataMember(Name = "auth_accounts")]
        public required AuthAccount[] AuthAccounts { get; set; }


        ///<summary>
        ///The discounted trading fee that applies to the auction slot holder,
        ///and any eligible accounts, when trading against this AMM.
        ///This is 1/10 of the AMM's normal trading fee.
        ///</summary>
        [DataMember(Name = "discounted_fee")]
        public required uint DiscountedFee { get; set; }

        ///<summary>
        ///The ISO 8601 UTC timestamp after which this auction slot expires.
        ///After expired, the auction slot does not apply
        ///(but the data can remain in the ledger until another transaction replaces it or cleans it up).
        ///</summary>
        [DataMember(Name = "expiration")]
        public required string Expiration {  get; set; }

        ///<summary>
        ///The amount, in LP Tokens, that the auction slot holder paid to win the auction slot.
        ///This affects the price to outbid the current slot holder.
        ///</summary>
        [DataMember(Name = "price")]
        public required LPTokenAmount Price { get; set; }

        ///<summary>
        ///The current 72-minute time interval this auction slot is in, from 0 to 19.
        ///The auction slot expires after 24 hours (20 intervals of 72 minutes) and
        ///affects the cost to outbid the current holder and how much the current holder
        ///is refunded if someone outbids them.
        ///</summary>
        [DataMember(Name = "time_interval")]
        public required uint TimeInterval { get; set; }
    }


    ///<summary>
    ///Each entry in the vote_slots array represents one liquidity provider's vote to set the trading fee.
    ///</summary>
    [DataContract]
    public class VoteSlot
    {
        ///<summary>
        ///The Address of this liquidity provider.
        ///</summary>
        [DataMember(Name = "account")]
        public required string Account { get; set; }

        ///<summary>
        ///The trading fee this liquidity provider voted for, in units of 1/100,000.
        ///</summary>
        [DataMember(Name = "trading_fee")]
        public required uint TradingFee { get; set; }

        ///<summary>
        ///How much this liquidity provider's vote counts towards the final trading fee.
        ///This is proportional to how much of the AMM's LP Tokens this liquidity provider holds.
        ///The value is equal to 100,000 times the number of this LP Tokens this liquidity provider holds,
        ///divided by the total number of LP Tokens outstanding. For example, a value of 1000 means that
        ///the liquidity provider holds 1% of this AMM's LP Tokens.
        ///</summary>
        [DataMember(Name = "vote_weight")]
        public required uint VoteWeight { get; set;}
    }
}
