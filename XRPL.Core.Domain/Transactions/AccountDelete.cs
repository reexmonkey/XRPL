using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that deletes an account (<see cref="AccountRoot"/>) and any objects it owns in the XRP Ledger, if possible, sending the account's remaining XRP to a specified destination account.
    /// <para/>See Deleting Accounts (https://xrpl.org/docs/concepts/accounts/deleting-accounts/) for the requirements to delete an account.
    /// </summary>
    public class AccountDelete : Transaction
    {
        /// <summary>
        /// The address of an account to receive any leftover XRP after deleting the sending account.
        /// <para/>Must be a funded account in the ledger, and must not be the sending account.
        /// </summary>
        public required string Destination { get; set; }

        /// <summary>
        /// (Optional) Arbitrary destination tag that identifies a hosted recipient or other information for the recipient of the deleted account's leftover XRP.
        /// </summary>
        public uint? DestinationTag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDelete"/> class.
        /// </summary>
        public AccountDelete() : base(TransactionType.AccountDelete)
        {
        }
    }
}