using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that votes on the trading fee for an Automated Market Maker instance.
    /// Up to 8 accounts can vote in proportion to the amount of the AMM's LP Tokens they hold.
    /// Each new vote re-calculates the AMM's trading fee based on a weighted average of the votes.
    /// </summary>
    [JsonDerivedType(typeof(AMMVote), typeDiscriminator: nameof(AMMVote))]
    public class AMMVote : Transaction
    {
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
        /// The proposed fee to vote for, in units of 1/100,000; a value of 1 is equivalent to 0.001%. The maximum value is 1000, indicating a 1% fee.
        /// </summary>
        public required uint TradingFee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMVote"/> class.
        /// </summary>
        protected AMMVote() : base(TransactionType.AMMVote)
        {
        }
    }
}