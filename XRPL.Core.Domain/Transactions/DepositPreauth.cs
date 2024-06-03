using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that gives another account pre-approval to deliver payments to the sender of this transaction. This is only useful if the sender of this transaction is using (or plans to use) Deposit Authorization (https://xrpl.org/docs/concepts/accounts/depositauth/).
    /// <para/>Tip: You can use this transaction to preauthorize certain counterparties before you enable Deposit Authorization. This may be useful to ensure a smooth transition from not requiring deposit authorization to requiring it.
    /// <para/>Catution: You must provide either Authorize or Unauthorize, but not both.
    /// </summary>
    [JsonDerivedType(typeof(DepositPreauth), typeDiscriminator: nameof(DepositPreauth))]
    public class DepositPreauth : Transaction
    {
        /// <summary>
        /// (Optional) The XRP Ledger address of the sender to preauthorize.
        /// </summary>
        public string? Authorize { get; set; }

        /// <summary>
        /// (Optional) The XRP Ledger address of a sender whose preauthorization should be revoked.
        /// </summary>
        public string? Unauthorize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositPreauth"/> class.
        /// </summary>
        protected DepositPreauth() : base(TransactionType.DepositPreauth)
        {
        }
    }
}