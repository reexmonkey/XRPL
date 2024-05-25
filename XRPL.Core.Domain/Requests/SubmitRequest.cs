using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Requests
{
    /// <summary>
    /// Represents a request that applies a transaction and sends it to the network to be confirmed and included in future ledgers.
    /// </summary>
    [DataContract]
    public class SubmitOnlyRequest : RequestBase<SubmitOnlyParameters>, IExpect<SubmitResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitOnlyRequest"/> class.
        /// </summary>
        public SubmitOnlyRequest() : base("submit")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="SubmitOnlyRequest"/> object.
    /// </summary>
    [DataContract]
    public class SubmitOnlyParameters : ParameterBase
    {
        /// <summary>
        /// Hex representation of the signed transaction to submit. This can be a multi-signed transaction.
        /// </summary>
        [JsonPropertyName("tx_blob")]
        public string? TxBlob { get; set; }

        /// <summary>
        /// If true, and the transaction fails locally, do not retry or relay the transaction to other servers. The default is false.
        /// </summary>
        [JsonPropertyName("fail_hard")]
        public bool FailHard { get; set; }
    }

    /// <summary>
    /// Represents a request that signs a transaction and immediately submits it.
    /// <para/>This mode is intended to be used for testing. You cannot use this mode for multi-signed transactions.
    /// </summary>
    [DataContract]
    public class SignAndSubmitRequest : RequestBase<SignAndSubmitParameters>, IExpect<SubmitResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignAndSubmitRequest"/> class.
        /// </summary>
        public SignAndSubmitRequest() : base("submit")
        {
        }
    }

    /// <summary>
    /// Represents the parameters of an <see cref="SignAndSubmitRequest"/> object.
    /// </summary>
    [DataContract]
    public class SignAndSubmitParameters : ParameterBase
    {
        /// <summary>
        /// Transaction definition in JSON format, optionally omitting any auto-fillable fields.
        /// </summary>
        [JsonPropertyName("tx_json")]
        public Transaction? TxJson { get; set; }

        /// <summary>
        /// (Optional) Secret key of the account supplying the transaction, used to sign it.
        /// <para/>Do not send your secret to untrusted servers or through unsecured network connections.
        /// Cannot be used with key_type, seed, seed_hex, or passphrase.
        /// </summary>
        [JsonPropertyName("secret")]
        public string? Secret { get; set; }

        /// <summary>
        /// (Optional) Secret key of the account supplying the transaction, used to sign it.
        /// Must be in the XRP Ledger's base58 format. If provided, you must also specify the key_type.
        /// Cannot be used with secret, seed_hex, or passphrase.
        /// </summary>
        [JsonPropertyName("seed")]
        public string? Seed { get; set; }

        /// <summary>
        /// (Optional) Secret key of the account supplying the transaction, used to sign it.
        /// Must be in hexadecimal format. If provided, you must also specify the key_type.
        /// Cannot be used with secret, seed, or passphrase.
        /// </summary>
        [JsonPropertyName("seed_hex")]
        public string? SeedHex { get; set; }

        /// <summary>
        /// (Optional) Secret key of the account supplying the transaction, used to sign it, as a string passphrase.
        /// <para/>If provided, you must also specify the key_type. Cannot be used with secret, seed, or seed_hex.
        /// </summary>
        [JsonPropertyName("passphrase")]
        public string? Passphrase { get; set; }

        /// <summary>
        /// (Optional) Type of cryptographic key provided in this request.
        /// <para/>Valid types are secp256k1 or ed25519.
        /// Defaults to secp256k1.
        /// Cannot be used with secret. Caution: Ed25519 support is experimental.
        /// </summary>
        [JsonPropertyName("key_type")]
        public KeyType? KeyType { get; set; }

        /// <summary>
        /// (Optional) If true, and the transaction fails locally, do not retry or relay the transaction to other servers.
        /// <para/>The default is false.
        /// </summary>
        [JsonPropertyName("fail_hard")]
        public bool? FailHard { get; set; }

        /// <summary>
        /// (Optional) If true, when constructing the transaction, do not try to automatically fill in or validate values.
        /// <para/>The default is false.
        /// </summary>
        [JsonPropertyName("offline")]
        public bool? Offline { get; set; }

        /// <summary>
        /// (Optional) If this field is provided, the server auto-fills the Paths field of a Payment transaction before signing.
        /// <para/>You must omit this field if the transaction is a direct XRP payment or if it is not a Payment-type transaction.
        /// Caution: The server looks for the presence or absence of this field, not its value. This behavior may change.
        /// </summary>
        [JsonPropertyName("build_path")]
        public bool? BuildPath { get; set; }

        /// <summary>
        /// (Optional) Sign-and-submit fails with the error rpcHIGH_FEE if the auto-filled Fee value would be greater than the reference transaction cost × fee_mult_max ÷ fee_div_max.
        /// This field has no effect if you explicitly specify the Fee field of the transaction. The default is 10.
        /// </summary>
        [JsonPropertyName("fee_mult_max")]
        public int? FeeMultMax { get; set; }

        /// <summary>
        /// (Optional) Sign-and-submit fails with the error rpcHIGH_FEE if the auto-filled Fee value would be greater than the reference transaction cost × fee_mult_max ÷ fee_div_max.
        /// <para/>This field has no effect if you explicitly specify the Fee field of the transaction. The default is 1.
        /// </summary>
        [JsonPropertyName("fee_div_max")]
        public int? FeeDivMax { get; set; }
    }

    public enum KeyType
    {
        secp256k1,
        ed25519
    }
}