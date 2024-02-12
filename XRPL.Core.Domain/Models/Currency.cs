using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    public class TokenCurrency
    {
        [DataMember(Name = "value")]
        public string? Value { get; set; }

        [DataMember(Name = "currency")]
        public string? Currency { get; set; }
    }
}
