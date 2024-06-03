using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that assigns, changes, or removes the regular key pair associated with an account.
    /// <para/>You can protect your account by assigning a regular key pair to it
    /// and using it instead of the master key pair to sign transactions whenever possible.
    /// If your regular key pair is compromised, but your master key pair is not,
    /// you can use a SetRegularKey transaction to regain control of your account.
    /// </summary>
    [JsonDerivedType(typeof(SetRegularKey), typeDiscriminator: nameof(SetRegularKey))]
    public class SetRegularKey : Transaction
    {
        /// <summary>
        /// (Optional) A base-58-encoded Address that indicates the regular key pair to be assigned to the account.
        /// <para/>If omitted, removes any existing regular key pair from the account.
        /// Must not match the master key pair for the address.
        /// </summary>
        public required uint RegularKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetRegularKey"/> class.
        /// </summary>
        public SetRegularKey() : base(TransactionType.SetRegularKey)
        {
        }
    }
}