using System.Collections;
using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Models
{
    public abstract record PaymentPathStep
    {
        /// <summary>
        /// (Optional) An indicator of which other fields are present.
        /// </summary>
        [Obsolete("DEPRECATED")]
        [JsonPropertyName("type")]
        public int? Type { get; init; }

        /// <summary>
        /// (Optional) A hexadecimal representation of the type field.
        /// </summary>
        [Obsolete("DEPRECATED")]
        [JsonPropertyName("type_hex")]
        public string? TypeHex { get; init; }
    }

    public record AccountPaymentPathStep : PaymentPathStep
    {
        /// <summary>
        /// (Optional) If present, this path step represents rippling through the specified address.
        /// </summary>
        [JsonPropertyName("account")]
        public required string Account { get; init; }
    }

    public record CurrencyPaymentPathStep : PaymentPathStep
    {
        /// <summary>
        /// (Optional) If present, this path step represents rippling through the specified currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }
    }

    public record IssuerPaymentPathStep : PaymentPathStep
    {
        /// <summary>
        /// (Optional) If present, this path step represents changing currencies and this address defines the issuer of the new currency.
        /// If omitted in a step with a non-XRP currency, a previous step of the path defines the issuer.
        /// If present when currency is omitted, indicates a path step that uses an order book or AMM between same-named currencies with different issuers.
        /// <para/> MUST be omitted if the currency is XRP
        /// <para/>
        /// </summary>
        [JsonPropertyName("issuer")]
        public required string Issuer { get; init; }
    }

    public record TokenPaymentPathStep : PaymentPathStep
    {
        /// <summary>
        /// (Optional) If present, this path step represents rippling through the specified currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public required string Currency { get; init; }

        /// <summary>
        /// (Optional) If present, this path step represents changing currencies and this address defines the issuer of the new currency.
        /// If omitted in a step with a non-XRP currency, a previous step of the path defines the issuer.
        /// If present when currency is omitted, indicates a path step that uses an order book or AMM between same-named currencies with different issuers.
        /// <para/> MUST be omitted if the currency is XRP
        /// <para/>
        /// </summary>
        [JsonPropertyName("issuer")]
        public required string Issuer { get; init; }
    }

    /// <summary>
    /// Represents a mutable sequence of payment path steps used to define and manage the flow of payment processing
    /// operations.
    /// </summary>
    /// <remarks>The PaymentPath class implements the IList interface, allowing for dynamic modification of
    /// the payment path, including adding, removing, inserting, and accessing individual steps. This enables flexible
    /// construction and traversal of payment processing sequences. The class is not read-only and supports enumeration
    /// for integration with collection-based APIs.</remarks>
    public class PaymentPath : IList<PaymentPathStep>
    {
        private readonly List<PaymentPathStep> steps = [];

        public PaymentPath()
        { }

        public PaymentPath(IEnumerable<PaymentPathStep> steps)
        {
            this.steps.AddRange(steps);
        }

        public PaymentPathStep this[int index] { get => steps[index]; set => steps[index] = value; }
        public int Count => steps.Count;
        public bool IsReadOnly => false;

        public void Add(PaymentPathStep item) => steps.Add(item);

        public void Clear() => steps.Clear();

        public bool Contains(PaymentPathStep item) => steps.Contains(item);

        public void CopyTo(PaymentPathStep[] array, int arrayIndex) => steps.CopyTo(array, arrayIndex);

        public IEnumerator<PaymentPathStep> GetEnumerator() => steps.GetEnumerator();

        public int IndexOf(PaymentPathStep item) => steps.IndexOf(item);

        public void Insert(int index, PaymentPathStep item) => steps.Insert(index, item);

        public bool Remove(PaymentPathStep item) => steps.Remove(item);

        public void RemoveAt(int index) => steps.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => steps.GetEnumerator();
    }

    [JsonSerializable(typeof(PaymentPath))]
    [JsonSerializable(typeof(AccountPaymentPathStep))]
    [JsonSerializable(typeof(CurrencyPaymentPathStep))]
    [JsonSerializable(typeof(IssuerPaymentPathStep))]
    [JsonSerializable(typeof(TokenPaymentPathStep))]
    public partial class PaymentPathContext : JsonSerializerContext;
}