using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Models
{
    public class STIssue
    {
        public string? Currency { get; set; }

        public string? Issuer { get; set; }

    }

    public class AMM
    {
        public STIssue? Asset { get; set; }

        public STIssue? Asset2 { get; set; }

        public string? Account {  get; set; }

        public AuctionSlot? AuctionSlot { get; set; }

        public TokenCurrencyAmount? LPTokenBalance { get; set; }

        public uint TradingFee { get; set; }

        public VoteEntry[]? VoteSlots { get; set; }
    }

    public class VoteEntry
    {
        public string? Account { get; set; }

        public ushort TradingFee { get; set; }

        public uint VoteWeight { get; set; }
    }

    public class AuctionSlot
    {
        public string? Account { get; set;}

        public AuthAccount[]? AuthAccounts { get; set; }

        public string? DiscountedFee { get; set; }

        public TokenCurrencyAmount? Price { get; set; }

        public string? Expiration { get; set; }
    }

    public class AuthAccount
    {
        public string? Account { get; set;}
    }
}
