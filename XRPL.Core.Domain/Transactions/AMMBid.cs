using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a bid on an Automated Market Maker's (AMM's) auction slot.
    /// <para/>If you win, you can trade against the AMM at a discounted fee until you are outbid or 24 hours have passed. If you are outbid before 24 hours have passed, you are refunded part of the cost of your bid based on how much time remains.
    /// <para/>You bid using the AMM's LP Tokens; the amount of a winning bid is returned to the AMM, decreasing the outstanding balance of LP Tokens.
    /// </summary>
    public class AMMBid : Transaction
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
        /// Pay at least this amount for the slot.
        /// <para/>Setting this value higher makes it harder for others to outbid you. If omitted, pay the minimum necessary to win the bid.
        /// </summary>
        public required LPTokenAmount BidMin { get; set; }

        /// <summary>
        /// Pay at most this amount for the slot.
        /// <para/>If the cost to win the bid is higher than this amount, the transaction fails. If omitted, pay as much as necessary to win the bid.
        /// </summary>
        public required LPTokenAmount BidMax { get; set; }

        /// <summary>
        /// A list of up to 4 additional accounts that you allow to trade at the discounted fee.
        /// <para/>This cannot include the address of the transaction sender.
        /// Each of these objects should be an Auth Account object.
        /// </summary>
        public AuthAccount[]? AuthAccounts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMBid"/> class.
        /// </summary>
        public AMMBid() : base(TransactionType.AMMBid)
        {
        }
    }
}
