using System.Runtime.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Responses
{
    /// <summary>
    /// Represents a response that encapsulates a list of validated transactions that involve a given account.
    /// </summary>
    [DataContract]
    public class GatewayBalancesResponse : ResponseBase<GatewayBalancesResult>
    {
    }

    /// <summary>
    /// Represents a result of an <see cref="GatewayBalancesResponse"/> object.
    /// </summary>
    [DataContract]
    [KnownType(typeof(BinaryAccountTransaction))]
    [KnownType(typeof(JsonAccountTransaction))]
    public class GatewayBalancesResult : ResultBase
    {
        /// <summary>
        /// The address of the account that issued the balances.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// (Omitted if empty) Total amounts issued to addresses not excluded, as a map of currencies to the total value issued.
        /// </summary>
        [JsonPropertyName("obligations")]
        public Dictionary<string, string>? Obligations { get; set; }

        /// <summary>
        /// (Omitted if empty) Amounts issued to the hotwallet addresses from the request.
        /// <para/>The keys are addresses and the values are arrays of currency amounts they hold.
        /// </summary>
        [JsonPropertyName("balances")]
        public Dictionary<string, TokenAmount[]>? Balances { get; set; }

        /// <summary>
        /// (Omitted if empty) Total amounts held that are issued by others.
        /// <para/>In the recommended configuration, the issuing address should have none.
        /// </summary>
        [JsonPropertyName("assets")]
        public Dictionary<string, TokenAmount[]>? Assets { get; set; }

        /// <summary>
        /// (May be omitted) The identifying hash of the ledger version that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (May be omitted) The ledger index of the ledger version that was used to generate this response.
        /// </summary>
        [JsonPropertyName("ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// (Omitted if ledger_current_index is provided) The ledger index of the current in-progress ledger version, which was used to retrieve this information.
        /// </summary>
        [JsonPropertyName("ledger_current_index")]
        public int? LedgerCurrentIndex { get; set; }
    }
}