using System.Text.Json.Serialization;
using XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.JsonRpc.PathAndOrderBookMethods
{
    /// <summary>
    /// Gets information about an Automated Market Maker (AMM) instance.
    /// </summary>
    public record AMMInfoRequest : Request, IExpect<AMMInfoResponse>
    {
        /// <summary>
        /// Gets the collection of parameters used to configure the ledger operation.
        /// </summary>
        [JsonPropertyName("params")]
        public AMMInfoParameters[]? Parameters { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AMMInfoRequest"/> class.
        /// </summary>
        public AMMInfoRequest() : base("amm_info")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AMMInfoRequest"/> object.
    /// </summary>
    public record AMMInfoParameters : Parameter
    {
        /// <summary>
        /// Show only LP Tokens held by this liquidity provider.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; init; }

        ///<summary>
        ///The address of the AMM's special AccountRoot. (This is the issuer of the AMM's LP Tokens.)
        ///</summary>
        [JsonPropertyName("amm_account")]
        public string? AmmAccount { get; init; }

        /// <summary>
        /// One of the assets of the AMM to look up, as an object with currency and issuer fields (omit issuer for XRP), like currency amounts.
        /// </summary>
        [JsonPropertyName("asset")]
        public Issue? Asset { get; init; }

        /// <summary>
        /// The other of the assets of the AMM, as an object with currency and issuer fields (omit issuer for XRP), like currency amounts.
        /// </summary>
        [JsonPropertyName("asset2")]
        public Issue? Asset2 { get; init; }
    }

}
