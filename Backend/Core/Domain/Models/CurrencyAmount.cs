using System.Text.Json;
using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents an amount of currency, which could be XRP, a non-XRP token, or a Multi-purpose Token (MPT).
    /// <para/>This abstract record serves as a base type for specific currency amount representations, allowing for polymorphic handling of different currency types in the XRP Ledger.
    /// Each derived record (XRPAmount, TokenAmount, MPTAmount) encapsulates the unique properties and constraints associated with its respective currency type,
    /// enabling precise modeling of financial transactions and balances within the ledger.
    /// </summary>
    public abstract record CurrencyAmount;

    public record XRPAmount : CurrencyAmount
    {
        /// <summary>
        /// The amount of XRP, represented as a string of drops. One XRP is equal to 1,000,000 drops.
        /// </summary>
        public required string Value { get; init; }
    }

    /// <summary>
    /// Provides custom JSON serialization and deserialization for the XRPAmount type, supporting both string and
    /// numeric JSON representations.
    /// </summary>
    /// <remarks>This converter enables seamless conversion between JSON values and XRPAmount instances.
    /// During deserialization, it accepts either a string or a number token and constructs an XRPAmount accordingly. If
    /// the JSON token is not a string or number, a JsonException is thrown. This ensures that only valid formats are
    /// processed and helps prevent data inconsistencies when working with XRPAmount in JSON payloads.</remarks>
    public class XRPAmountConverter : JsonConverter<XRPAmount>
    {
        public override XRPAmount Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string value = reader.GetString()!;
                return new XRPAmount { Value = value };
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                string value = reader.GetInt64().ToString();
                return new XRPAmount { Value = value };
            }
            throw new JsonException("Invalid JSON token for XRPAmount. Expected string or number.");
        }

        public override void Write(Utf8JsonWriter writer, XRPAmount amount, JsonSerializerOptions options)
        {
            writer.WriteStringValue(amount.Value);
        }
    }

    /// <summary>
    /// Represents a non-XRP token amount, including its currency code, value, and issuer information.
    /// </summary>
    /// <remarks>The currency code must not be "XRP". The value is a quoted decimal string and may use
    /// scientific notation (e.g., "1.23e11"). Negative values are permitted when displaying balances but are not
    /// allowed in contexts such as sending tokens. To define a token asset without specifying an amount, use a currency
    /// object without the value field. The issuer typically identifies the account that issues the token, but in
    /// certain scenarios (such as Clawback transactions), it may refer to the account holding the token.</remarks>
    public record TokenAmount : CurrencyAmount
    {
        /// <summary>
        /// Arbitrary currency code for the token. Cannot be XRP.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }

        /// <summary>
        /// Quoted decimal representation of the amount of the token.
        /// <para/>
        /// This can include scientific notation, such as 1.23e11 meaning 123,000,000,000. Both e and E may be used. This can be negative when displaying balances, but negative values are disallowed
        /// in other contexts such as specifying how much to send.
        /// <para/>
        /// In some cases, you need to define an asset (which could be XRP or a token) without a specific amount, such as when defining an order book in the decentralized exchange. To describe a token
        /// without an amount, specify it as a currency object, but omit the value field.
        /// </summary>
        [JsonPropertyName("value")]
        public required string Value { get; init; }

        /// <summary>
        /// Generally, the account that issues this token.
        /// <para/>
        /// In special cases, this can refer to the account that holds the token instead (for example, in a Clawback transaction).
        /// </summary>
        [JsonPropertyName("issuer")]
        public required string Issuer { get; init; }
    }

    /// <summary>
    /// Represents an amount of a Multi-purpose Token (MPT), including a unique identifier and a value.
    /// </summary>
    /// <remarks>The Value property stores a positive integer as a string, with valid values ranging from 0x0
    /// to 0x7FFFFFFFFFFFFFFF. To represent fractional token amounts, use the AssetScale property in conjunction with
    /// Value. This class is typically used to specify token quantities in transactions or balances where precise
    /// identification and value representation are required.</remarks>
    public record MPTAmount : CurrencyAmount
    {
        /// <summary>
        /// Arbitrary unique identifier for a Multi-purpose Token.
        /// </summary>
        [JsonPropertyName("mpt_issuance_id")]
        public required string MptIssuanceId { get; init; }

        /// <summary>
        /// A string representing a positive integer value. Valid values for this field are between 0x0 and 0x7FFFFFFFFFFFFFFF. Use AssetScale to enable values as fractions of the MPT value
        /// </summary>
        [JsonPropertyName("value")]
        public required string Value { get; init; }
    }
}