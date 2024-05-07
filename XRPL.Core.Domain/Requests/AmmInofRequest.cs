using System.Runtime.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// The amm_info method gets information about an Automated Market Maker (AMM) instance.
    /// </summary>
    [DataContract]
    public class AmmInofRequest : RequestBase<AmmInfoParameters>, IExpect<AmmInfoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmmInfoRequest"/> class.
        /// </summary>
        public AmmInofRequest() : base("amm_info")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AmmInfoRequest"/> object.
    /// </summary>
    [DataContract]
    public class AmmInfoParameters : ParameterBase
    {
        /// <summary>
        /// Show only LP Tokens held by this liquidity provider.
        /// </summary>
        [DataMember(Name = "account")]
        public string? Account { get; set;}

        ///<summary>
        ///The address of the AMM's special AccountRoot. (This is the issuer of the AMM's LP Tokens.)
        ///</summary>
        [DataMember(Name = "amm_account")]
        public string? AmmAccount { get; set;}

        ///<summary>
        ///One of the assets of the AMM to look up, as an object with currency and issuer fields (omit issuer for XRP),
        ///like currency amounts.
        ///</summary>
        [DataMember(Name = "asset")]
        public FungibleToken? Asset { get; set;}

        ///<summary>
        ///The other of the assets of the AMM, as an object with currency and issuer fields (omit issuer for XRP),
        ///like currency amounts.
        ///</summary>
        [DataMember(Name = "asset2")]
        public LPToken? Asset2 { get; set;}

    }
}
