using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    public abstract class CurrencyAmountBase<TAmount>
        where TAmount : class
    {
        public TAmount? Amount { get; set; }
    }

    public sealed class XrpCurrencyAmount: CurrencyAmountBase<string>
    {

    }

    public class TokenAmount
    {
        [DataMember(Name = "value")]
        public string? Value { get; set; }

        [DataMember(Name = "currency")]
        public string? Currency { get; set; }

        [DataMember(Name = "issuer")]
        public string? Issuer { get; set; }
    }

    public sealed class TokenCurrencyAmount: CurrencyAmountBase<TokenAmount>
    {

    }

}
