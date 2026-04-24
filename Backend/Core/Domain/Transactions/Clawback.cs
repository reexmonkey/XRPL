using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that claws back tokens issued by your account.
    /// <para/> Issuers can only claw back trust line tokens if they enabled the Allow Trust Line Clawback setting before issuing any tokens.
    /// <para/> Issuers can claw back MPTs if the corresponding MPT Issuance has clawback enabled.
    /// <para/>When clawing back trust line tokens, you must omit the Holder field. When clawing back MPTs, you must provide the Holder field.
    /// </summary>
    public class Clawback : Transaction
    {
        /// <summary>
        /// Indicates the amount being clawed back, as well as the counterparty from which the amount is being clawed back.
        /// The quantity to claw back, in the value sub-field, must not be zero.
        /// If this is more than the current balance, the transaction claws back the entire balance.
        /// The sub-field issuer within Amount represents the token holder's account ID, rather than the issuer's.
        /// </summary>
        public required CurrencyAmount Amount { get; set; }

        /// <summary>
        /// The holder to claw back tokens from, if clawing back MPTs.
        /// The holder must have a non-zero balance of the MPT issuance indicated in the Amount field.
        /// </summary>
        public string? Holder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clawback"/> class.
        /// </summary>
        public Clawback() : base(TransactionType.Clawback)
        {
        }
    }

    [JsonSerializable(typeof(Clawback))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class ClawbackContext : JsonSerializerContext;
}