using System.Text.Json.Serialization;
using System.Transactions;

namespace XRPL.Core.Domain.Methods.JsonRpc.TransactionMethods
{
    /// <summary>
    /// Represents a request that applies a multi-signed transaction and sends it to the network to be included in future ledgers.
    /// You can also submit multi-signed transactions in binary form using the submit command in submit-only mode.
    /// </summary>
    public record SubmitMultisignedRequest : Request, IExpect<SubmitMultisignedResponse>
    {
        [JsonPropertyName("params")]
        public SubmitMultisignedParameter[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitMultisignedRequest"/> record.
        /// </summary>
        public SubmitMultisignedRequest() : base("submit_multisigned")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="SubmitMultisignedRequest"/> object.
    /// </summary>
    public record SubmitMultisignedParameter : Parameter
    {
        /// <summary>
        /// Transaction in JSON format with an array of Signers. To be successful, the weights of the signatures must be equal or higher than the quorum of the SignerList.
        /// </summary>
        [JsonPropertyName("tx_json")]
        public required Transaction TxJson { get; init; }

        /// <summary>
        /// If true, and the transaction fails locally, do not retry or relay the transaction to other servers. The default is false.
        /// </summary>
        [JsonPropertyName("fail_hard")]
        public bool FailHard { get; init; }
    }
}
