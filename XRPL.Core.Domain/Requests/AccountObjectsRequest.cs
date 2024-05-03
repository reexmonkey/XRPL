using System.Runtime.Serialization;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents the raw ledger format for all ledger entries owned by an account.
    /// <para/>For a higher-level view of an account's trust lines and balances, see the <see cref="AccountLinesRequest"/> instead.
    /// <para/>The types of objects that may appear in the account_objects response include:
    /// <para/><see cref="XrpForFungibleTokenOffer"/> entries for orders that are currently live, unfunded, or expired but not yet removed.
    /// <para/><see cref="RippleState"/> entries for trust lines where this account's side is not in the default state.
    /// <para/>The account's <see cref="SignerList"/>, if the account has multi-signing enabled.
    /// <para/><see cref="Escrow"/> entries for held payments that have not yet been executed or canceled.
    /// <para/><see cref="PayChannel"/> entries for open payment channels.
    /// <para/><see cref="XrpCheck"/>, <see cref="FungibleTokenCheck"/> entries for pending Checks.
    /// <para/><see cref="DepositPreauth"/> entries for deposit preauthorizations.
    /// <para/><see cref="Ticket"/> entries for Tickets.
    /// <para/><see cref="XrpForNFTokenOffer"/>,
    /// <see cref="FungibleTokenForNFTokenOffer"/>,
    /// <see cref="FungibleTokenOffer"/> entries for offers to buy or sell an NFT.
    /// <para/><see cref="NFTokenPage"/> entries for collections of NFTs.
    /// </summary>
    [DataContract]
    public class AccountObjectsRequest : RequestBase<AccountObjectsParameters>, IExpect<AccountObjectsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountObjectsRequest"/> class.
        /// </summary>
        public AccountObjectsRequest() : base("account_objects")
        {
        }
    }

    /// <summary>
    /// Represents parameters of an <see cref="AccountObjectsRequest"/> object.
    /// </summary>
    [DataContract]
    public class AccountObjectsParameters : ParameterBase
    {
        /// <summary>
        /// A unique identifier for the account, most commonly the account's Address.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set; }

        /// <summary>
        /// If true, the response only includes objects that would block this account from being deleted. The default is false.
        /// </summary>
        [DataMember(Name = "deletion_blockers_only")]
        public bool? DeletionBlockersOnly { get; set; }

        /// <summary>
        /// A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// The maximum number of objects to include in the results.
        /// <para/>Must be within the inclusive range 10 to 400 on non-admin connections.
        /// The default is 200.
        /// </summary>
        [DataMember(Name = "limit")]
        public uint? Limit { get; set; }

        /// <summary>
        /// Value from a previous paginated response.
        /// <para/>Resume retrieving data where that response left off.
        /// </summary>
        [DataMember(Name = "marker")]
        public object? Marker { get; set; }

        /// <summary>
        /// Filter results by a ledger entry type.
        /// <para/>The valid types are: check, deposit_preauth, escrow, nft_offer, nft_page, offer, payment_channel, signer_list, state (trust line), and ticket.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Type { get; set; }
    }
}