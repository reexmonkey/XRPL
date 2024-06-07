using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.BookOffers
{
    /// <summary>
    /// Represent a request that retrieves a list of Offers between two currencies,
    /// also known as an order book. The response omits unfunded Offers and reports
    /// how much of each remaining Offer's total is currently funded.
    /// </summary>
    public class BookOffersRequest : RequestBase<BookOffersParameters>, IExpect<BookOffersResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookOffersRequest"/> class.
        /// </summary>
        public BookOffersRequest() : base("book_offers")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="BookOffersRequest"/> object.
    /// </summary>
    public class BookOffersParameters : ParameterBase
    {
        ///<summary>
        ///The asset the account taking the Offer would receive, as a currency without an amount.
        ///</summary>
        [JsonPropertyName("taker_gets")]
        public required TokenAmount TakerGets { get; set; }

        ///<summary>
        ///The asset the account taking the Offer would pay, as a currency without an amount.
        ///</summary>
        [JsonPropertyName("taker_pays")]
        public required TokenAmount TakerPays { get; set; }

        ///<summary>
        ///A 20-byte hex string for the ledger version to use. (See Specifying Ledgers)
        ///</summary>
        [JsonPropertyName("ledger_hash")]
        public string? LedgerHash { get; set; }

        ///<summary>
        ///	The ledger index of the ledger to use, or a shortcut string to choose a ledger automatically. (See Specifying Ledgers)
        ///</summary>
        [JsonPropertyName("ledger_index")]
        public uint? LedgerIndex { get; set; }

        ///<summary>
        ///	The maximum number of Offers to return. The response may include fewer results.
        ///</summary>
        [JsonPropertyName("limit")]
        public uint? Limit { get; set; }

        ///<summary>
        ///The Address of an account to use as a perspective.
        ///The response includes this account's Offers even if they are unfunded.
        ///(You can use this to see what Offers are above or below yours in the order book.)
        ///</summary>
        [JsonPropertyName("taker")]
        public string? Taker { get; set; }
    }
}
