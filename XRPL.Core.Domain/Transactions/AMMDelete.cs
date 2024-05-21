using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes an empty Automated Market Maker (AMM) instance that could not be fully deleted automatically.
    /// <para/>Normally, an AMMWithdraw transaction automatically deletes an AMM and all associated ledger entries when it withdraws all the assets from the AMM's pool. However, if there are too many trust lines to the AMM account to remove in one transaction, it may stop before fully removing the AMM. Similarly, an <see cref="AMMDelete"/> transaction removes up to a maximum of 512 trust lines; it may take several <see cref="AMMDelete"/> transactions to delete all the trust lines and the associated AMM. In all cases, only the last such transaction deletes the AMM and <see cref="AccountRoot"/> ledger entries.
    /// </summary>
    public class AMMDelete : Transaction
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
        /// Initializes a new instance of the <see cref="AMMDelete"/> class.
        /// </summary>
        protected AMMDelete() : base(TransactionType.AMMDelete)
        {
        }
    }
}