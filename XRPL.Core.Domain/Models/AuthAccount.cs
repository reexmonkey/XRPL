using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Models
{
    /// <summary>
    /// Represents an account that is authorized to trade at the discounted fee for an <see cref="AMM"/> instance.
    /// </summary>
    public class AuthAccount
    {
        /// <summary>
        /// The address of the account to authorize.
        /// </summary>
        public required string Account { get; set; }
    }
}