using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Methods.PathAndOrderBookMethods.AmmInfo
{
    /// <summary>
    /// Represents a request to get information about an Automated Market Maker (AMM) instance by looking up the address of the AMM's special AccountRoot.
    /// This is the issuer of the AMM's LP Tokens.
    /// </summary>
    public class AccountAmmInfoRequest : RequestBase<AccountAmmInfoParameters>, IExpect<AmmInfoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAmmInfoRequest"/> class.
        /// </summary>
        public AccountAmmInfoRequest() : base("amm_info")
        {
        }
    }

    /// <summary>
    /// Represents a request to get information about an Automated Market Maker (AMM) instance by looking up the assets of the AMM instance.
    /// </summary>
    public class AssetAmmInfoRequest : RequestBase<AssetAmmInfoParameters>, IExpect<AmmInfoResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetAmmInfoRequest"/> class.
        /// </summary>
        public AssetAmmInfoRequest() : base("amm_info")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AccountAmmInfoRequest"/> object.
    /// </summary>
    public class AccountAmmInfoParameters : ParameterBase
    {
        /// <summary>
        /// Show only LP Tokens held by this liquidity provider.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        ///<summary>
        ///The address of the AMM's special AccountRoot. (This is the issuer of the AMM's LP Tokens.)
        ///</summary>
        [JsonPropertyName("amm_account")]
        public required string AmmAccount { get; set; }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="AssetAmmInfoRequest"/> object.
    /// </summary>
    [JsonPolymorphic()]
    [JsonDerivedType(typeof(XrpFungibleTokenAmmInfoParameters), typeDiscriminator: nameof(XrpFungibleTokenAmmInfoParameters))]
    [JsonDerivedType(typeof(FungibleTokenXrpAmmInfoParameters), typeDiscriminator: nameof(FungibleTokenXrpAmmInfoParameters))]
    [JsonDerivedType(typeof(FungibleTokenAmmInfoParameters), typeDiscriminator: nameof(FungibleTokenAmmInfoParameters))]
    public abstract class AssetAmmInfoParameters : ParameterBase
    {
        /// <summary>
        /// Show only LP Tokens held by this liquidity provider.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        ///<summary>
        ///One of the assets of the AMM to look up, as an object with currency and issuer fields (omit issuer for XRP),
        ///like currency amounts.
        ///</summary>
        [JsonPropertyName("asset")]
        public object Asset { get; set; } = null!;

        ///<summary>
        ///The other of the assets of the AMM, as an object with currency and issuer fields (omit issuer for XRP),
        ///like currency amounts.
        ///</summary>
        [JsonPropertyName("asset2")]
        public object Asset2 { get; set; } = null!;
    }

    /// <summary>
    /// Represets the parameters of an <see cref="AssetAmmInfoRequest"/> for the AMM asset pair: XRP/Fungible Token Asset.
    /// </summary>
    [JsonDerivedType(typeof(XrpFungibleTokenAmmInfoParameters), typeDiscriminator: nameof(XrpFungibleTokenAmmInfoParameters))]
    public class XrpFungibleTokenAmmInfoParameters : AssetAmmInfoParameters
    {
        ///<summary>
        /// The XRP asset of the AMM to look up.
        ///</summary>
        [JsonPropertyName("asset")]
        public new required XrpAsset Asset { get => (XrpAsset)base.Asset; set => base.Asset = value; }

        ///<summary>
        ///The other of the assets of the AMM, as an object with currency and issuer fields like currency amounts.
        ///</summary>
        [JsonPropertyName("asset2")]
        public new required TokenAsset Asset2 { get => (TokenAsset)base.Asset2; set => base.Asset2 = value; }
    }

    /// <summary>
    /// Represets the parameters of an <see cref="AssetAmmInfoRequest"/> for the AMM asset pair: Fungible Token Asset/XRP.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenXrpAmmInfoParameters), typeDiscriminator: nameof(FungibleTokenXrpAmmInfoParameters))]
    public sealed class FungibleTokenXrpAmmInfoParameters : AssetAmmInfoParameters
    {
        ///<summary>
        /// One of the assets of the AMM to look up, as an object with currency and issuer fields (omit issuer for XRP), like currency amounts.
        ///</summary>
        [JsonPropertyName("asset")]
        public new required TokenAsset Asset { get => (TokenAsset)base.Asset; set => base.Asset = value; }

        ///<summary>
        ///The XRP asset of the AMM.
        ///</summary>
        [JsonPropertyName("asset2")]
        public new required XrpAsset Asset2 { get => (XrpAsset)base.Asset2; set => base.Asset2 = value; }
    }

    /// <summary>
    /// Represets the parameters of an <see cref="AssetAmmInfoRequest"/> for the AMM asset pair: Fungible Token Asset/Fungible Token Asset.
    /// </summary>
    [JsonDerivedType(typeof(FungibleTokenAmmInfoParameters), typeDiscriminator: nameof(FungibleTokenAmmInfoParameters))]
    public sealed class FungibleTokenAmmInfoParameters : AssetAmmInfoParameters
    {
        ///<summary>
        /// One of the assets of the AMM to look up, as an object with currency and issuer fields (omit issuer for XRP), like currency amounts.
        ///</summary>
        [JsonPropertyName("asset")]
        public new required TokenAsset Asset { get => (TokenAsset)base.Asset; set => base.Asset = value; }

        ///<summary>
        ///The XRP asset of the AMM.
        ///</summary>
        [JsonPropertyName("asset2")]
        public new required TokenAsset Asset2 { get => (TokenAsset)base.Asset2; set => base.Asset2 = value; }
    }
}
