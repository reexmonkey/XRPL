using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.DepositAuthorized
{
    /// <summary>
    /// The deposit_authorized command indicates whether one account is authorized to send payments directly to another.
    /// </summary>

    public class DepositAuthorizedRequest : RequestBase<DepositAuthorizedParameters>, IExpect<DepositAuthorizedResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositAuthorizedRequest"/> class.
        /// </summary>
        public DepositAuthorizedRequest() : base("deposit_authorized")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="DepositAuthorizedRequest"/> object.
    /// </summary>

    public abstract class DepositAuthorizedParameters : ParameterBase
    {
        /// <summary>
        /// The sender of a possible payment.
        /// </summary>
        [JsonPropertyName("source_account")]
        public required string SourceAccount { get; set; }

        /// <summary>
        /// The recipient of a possible payment.
        /// </summary>
        [JsonPropertyName("destination_acount")]
        public required string DestinationAccount { get; set; }

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// (See Specifying Ledgers)
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public string? LedgerIndex { get; set; }
    }
}
