using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    public class AMMClawback : Transaction
    {
        private AMMClawbackFlags? flags;

        /// <summary>
        /// The issuer of the asset being clawed back. Only the issuer can submit this transaction.
        /// </summary>
        public required override string Account { get; set; }

        /// <summary>
        /// Specifies the asset that the issuer wants to claw back from the AMM pool.
        /// The asset can be XRP, a token, or an MPT.
        /// <para/> The issuer field must match with Account.
        /// </summary>
        public required Issue Asset { get; set; }

        /// <summary>
        /// Specifies the other asset in the AMM's pool. The asset can be XRP, a token, or an MPT
        /// </summary>
        public required Issue Asset2 { get; set; }

        /// <summary>
        /// The maximum amount to claw back from the AMM account.
        /// <para/>The currency and issuer subfields should match the Asset subfields.
        /// <para/>If this field isn't specified, or the value subfield exceeds the holder's available tokens in the AMM, all of the holder's tokens are clawed back.
        /// </summary>
        public CurrencyAmount? Amount { get; set; }

        /// <summary>
        /// The account holding the asset to be clawed back.
        /// </summary>
        public required string Holder { get; set; }

        public override uint? Flags { get => (uint?)flags; set => flags = (AMMClawbackFlags?)value; }

        /// <summary>
        /// Initializes a new instance of the AMMClawback class, representing a clawback transaction, which claws back tokens from a holder who has deposited your issued tokens into an AMM pool..
        /// </summary>
        public AMMClawback() : base(TransactionType.Clawback)
        {
        }
    }

    public enum AMMClawbackFlags
    {
        /// <summary>
        /// Claw back the specified amount of Asset, and a corresponding amount of Asset2 based on the AMM pool's asset proportion;
        /// both assets must be issued by the issuer in the Account field.
        /// <para/>If this flag isn't enabled, the issuer claws back the specified amount of Asset,
        /// while a corresponding proportion of Asset2 goes back to the Holder.
        /// </summary>
        tfClawTwoAssets = 0x00000001
    }

    [JsonSerializable(typeof(AMMClawback))]
    [JsonSerializable(typeof(XRPIssue))]
    [JsonSerializable(typeof(TokenIssue))]
    [JsonSerializable(typeof(MPTIssue))]
    [JsonSerializable(typeof(XRPAmount))]
    [JsonSerializable(typeof(TokenAmount))]
    [JsonSerializable(typeof(MPTAmount))]
    public partial class AMMClawbackContext : JsonSerializerContext;
}