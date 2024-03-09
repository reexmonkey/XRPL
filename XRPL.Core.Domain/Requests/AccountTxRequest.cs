using System.Runtime.Serialization;
using XRPL.Core.Domain.Contracts;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request to retrieve a list of validated transactions that involve a given account.
    /// </summary>
    [DataContract]
    public class AccountTxRequest : RequestBase<AccountTxParameters>, IRelateTo<AccountTxResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTxRequest"/> class.
        /// </summary>
        public AccountTxRequest() : base("account_tx")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountTxRequest"/> object.
    /// </summary>
    [DataContract]
    public class AccountTxParameters : ParameterBase
    {
        /// <summary>
        /// A unique identifier for the account, most commonly the account's address.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// API v1: (Optional) Use to specify the earliest ledger to include transactions from.
        /// A value of -1 instructs the server to use the earliest validated ledger version available.
        /// <para/>API v2: Identical to v1, but also returns a lgrIdxMalformed error if a value is specified beyond the range of ledgers the server has.
        /// </summary>
        [DataMember(Name = "ledger_index_min")]
        public int? LedgerIndexMin { get; set; }

        /// <summary>
        /// API v1: (Optional) Use to specify the most recent ledger to include transactions from. A value of -1 instructs the server to use the most recent validated ledger version available.
        /// <para/>API v2: Identical to v1, but also returns a lgrIdxMalformed error if a value is specified beyond the range of ledgers the server has.
        /// </summary>
        [DataMember(Name = "ledger_index_max")]
        public int? LedgerIndexMax { get; set; }

        /// <summary>
        /// (Optional) Use to look for transactions from a single ledger only.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) Use to look for transactions from a single ledger only.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public int? LedgerIndex { get; set; }

        /// <summary>
        /// API v1: (Optional) Defaults to false. If set to true, returns transactions as hex strings instead of JSON.
        /// <para/>API v2: Identical to v1, but also returns an invalidParams error if you provide a non-boolean value.
        /// </summary>
        [DataMember(Name = "binary")]
        public bool? Binary { get; set; }

        /// <summary>
        /// API v1: (Optional) Defaults to false. If set to true, returns values indexed with the oldest ledger first. Otherwise, the results are indexed with the newest ledger first.
        /// (Each page of results may not be internally ordered, but the pages are overall ordered.)
        /// <para/>API v2: Identical to v1, but also returns an invalidParams error if you provide a non-boolean value.
        /// </summary>
        [DataMember(Name = "forward")]
        public bool? Forward { get; set; }

        /// <summary>
        /// (Optional) Default varies. Limit the number of transactions to retrieve. The server is not required to honor this value.
        /// </summary>
        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// <para/>This value is stable even if there is a change in the server's range of available ledgers.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }
}