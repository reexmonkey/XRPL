using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Responses
{

    public class Transaction
    {
        public bool AuthChange { get; set; }

        public string? Fee { get; set; }

        public string? FeeLevel { get; set; }

        public string? MaxSpendDrops { get; set; }

        public int Seq { get; set; }
    }

    public class QueueData
    { 
        public int TxnCount { get; set; }

        public bool AuthChangeQueued { get; set; }

        public int LowestSequence { get; set;}

        public int HighestSequence { get; set; }

        public string? MaxSpendDropsTotal { get; set; }

        public Transaction[]? Transactions { get; set; }
    }

    public class AccountFlags
    {
        public bool DefaultRipple { get; set;}

        public bool DepositAuth { get; set; }

        public bool DisableMasterKey { get; set;}

        public bool DisallowIncomingCheck { get; set;}

        public bool DisallowIncomingNFTokenOffer { get; set; }

        public bool DisallowIncomingTrustline { get; set; }

        public bool DisallowIncomingXRP { get; set; }

        public bool GlobalFreeze { get; set; }

        public bool NoFreeze { get; set; }

        public bool PasswordSpent { get; set; }

        public bool RequireAuthorization { get; set; }

        public bool RequireDestinationTag { get; set;}

    }

    public class AccountInfoResult: ResultBase
    {
        
    }

    public class AccountInfoResponse
    {
    }
}
