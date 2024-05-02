using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that attempts to redeem a <see cref="Check"/> object in the ledger to receive up to the amount authorized by the corresponding CheckCreate transaction.
    /// Only the Destination address of a <see cref="Check"/> can cash it with a <see cref="CheckCash"/> transaction.
    /// Cashing a check this way is similar to executing a Payment initiated by the destination.
    /// <para/> Since the funds for a check are not guaranteed, redeeming a <see cref="CheckCash"/> can fail because the sender does not have a high enough balance or because there is not enough liquidity to deliver the funds.
    /// If this happens, the <see cref="CheckCash"/> remains in the ledger and the destination can try to cash it again later, or for a different amount.
    /// </summary>
    public abstract class CheckCash : Transaction
    {
        /// <summary>
        /// The ID of the Check ledger object to cash, as a 64-character hexadecimal string.
        /// </summary>
        public required string CheckID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckCash"/> class.
        /// </summary>
        protected CheckCash() : base(TransactionType.CheckCash)
        {
        }
    }

    /// <summary>
    /// Specifies a transaction that attempts to redeem a <see cref="Check"/> object in the ledger to receive up to the amount authorized by the corresponding CheckCreate transaction.
    /// Only the Destination address of a <see cref="Check{TAmount}"/> can cash it with a <see cref="CheckCash{TAmount}"/> transaction.
    /// Cashing a check this way is similar to executing a Payment initiated by the destination.
    /// <para/> Since the funds for a check are not guaranteed, redeeming a <see cref="CheckCash{TAmount}"/> can fail because the sender does not have a high enough balance or because there is not enough liquidity to deliver the funds.
    /// If this happens, the <see cref="CheckCash{TAmount}"/> remains in the ledger and the destination can try to cash it again later, or for a different amount.
    /// <para/>Caution: The transaction must include either Amount or DeliverMin, but not both.
    /// </summary>
    /// <typeparam name="TAmount">The type of currency amount.</typeparam>
    public abstract class CheckCash<TAmount> : CheckCash
        where TAmount : class
    {
        /// <summary>
        /// (Optional) Redeem the Check for exactly this amount, if possible.
        /// The currency must match that of the SendMax of the corresponding CheckCreate transaction. You must provide either this field or DeliverMin.
        /// </summary>
        public TAmount? Amount { get; set; }

        /// <summary>
        /// (Optional) Redeem the Check for at least this amount and for as much as possible.
        /// The currency must match that of the SendMax of the corresponding CheckCreate transaction. You must provide either this field or Amount.
        /// </summary>
        public TAmount? DeliverMin { get; set; }
    }

    /// <summary>
    /// Represents a transaction that attempts to redeem an <see cref="XrpCheck"/> object in the ledger to receive up to the amount authorized by the corresponding CheckCreate transaction.
    /// Only the Destination address of an <see cref="XrpCheck"/> can cash it with an <see cref="XrpCheckCash"/> transaction.
    /// Cashing a check this way is similar to executing a Payment initiated by the destination.
    /// <para/> Since the funds for a check are not guaranteed, redeeming an <see cref="XrpCheck"/> can fail because the sender does not have a high enough balance or because there is not enough liquidity to deliver the funds.
    /// If this happens, the <see cref="XrpCheck"/> remains in the ledger and the destination can try to cash it again later, or for a different amount.
    /// <para/>Caution: The transaction must include either Amount or DeliverMin, but not both.
    /// </summary>
    public sealed class XrpCheckCash : CheckCash<string>
    {
    }

    /// <summary>
    /// Represents a transaction that attempts to redeem a <see cref="TokenCheck"/> object in the ledger to receive up to the amount authorized by the corresponding CheckCreate transaction.
    /// Only the Destination address of a <see cref="TokenCheck"/> can cash it with a <see cref="TokenCheckCash"/> transaction.
    /// Cashing a check this way is similar to executing a Payment initiated by the destination.
    /// <para/> Since the funds for a check are not guaranteed, redeeming a <see cref="TokenCheck"/> can fail because the sender does not have a high enough balance or because there is not enough liquidity to deliver the funds.
    /// If this happens, the <see cref="TokenCheck"/> remains in the ledger and the destination can try to cash it again later, or for a different amount.
    /// <para/>Caution: The transaction must include either Amount or DeliverMin, but not both.
    /// </summary>
    public sealed class TokenCheckCash : CheckCash<Token>
    {
    }
}