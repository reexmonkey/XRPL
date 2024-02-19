using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request to return a list of NFToken objects for the specified account.
    /// </summary>
    public class AccountNFTsRequest : RequestBase<AccountNftsParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountNFTsRequest"/> class.
        /// </summary>
        public AccountNFTsRequest() : base("account_nfts")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of a request to return a list of NFToken objects for the specified account.
    /// </summary>
    public class AccountNftsParameters : ParameterBase
    {
        /// <summary>
        /// The unique identifier of an account, typically the account's Address.
        /// <para/>The request returns a list of NFTs owned by this account.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// (Optional) A 20-byte hex string for the ledger version to use
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// (Optional) The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// (Optional) Limit the number of token pages to retrieve. Each page can contain up to 32 NFTs.
        /// <para/>The limit value cannot be lower than 20 or more than 400.
        /// Positive values outside this range are replaced with the closest valid option.
        /// The default is 100.
        /// </summary>
        [DataMember(Name = "limit")]
        public uint Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response. Resume retrieving data where that response left off.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }
    }
}