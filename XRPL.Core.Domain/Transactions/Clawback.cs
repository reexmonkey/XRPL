using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that claws back tokens issued by your account.
    /// Clawback is disabled by default.
    /// To use clawback, you must send an AccountSet transaction to enable the Allow Trust Line Clawback setting.
    /// An issuer with any existing tokens cannot enable Clawback.
    /// You can only enable Allow Trust Line Clawback if you have a completely empty owner directory, meaning you must do so before you set up any trust lines, offers, escrows, payment channels, checks, or signer lists.
    /// After you enable Clawback, it cannot reverted: the account permanently gains the ability to claw back issued assets on trust lines.
    /// </summary>
    public class Clawback : Transaction
    {
        /// <summary>
        /// Indicates the amount being clawed back, as well as the counterparty from which the amount is being clawed back.
        /// The quantity to claw back, in the value sub-field, must not be zero.
        /// If this is more than the current balance, the transaction claws back the entire balance.
        /// The sub-field issuer within Amount represents the token holder's account ID, rather than the issuer's.
        /// </summary>
        public required Token Amount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clawback"/> class.
        /// </summary>
        protected Clawback() : base(TransactionType.Clawback)
        {
        }
    }
}