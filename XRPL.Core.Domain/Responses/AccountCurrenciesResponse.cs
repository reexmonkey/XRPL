﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XRPL.Core.Domain.Responses
{
    public class AccountCurrenciesResponseResult : ResultBase
    {
        /// <summary>
        /// The identifying hash of the ledger version used to retrieve this data, as hex.
        /// </summary>
        [DataMember(Name = "ledger_hash")]
        public string? LedgerHash { get; set; }

        /// <summary>
        /// The ledger index of the ledger version used to retrieve this data.
        /// </summary>
        [DataMember(Name = "ledger_index")]
        public string? LedgerIndex { get; set; }

        /// <summary>
        /// Array of Currency Codes for currencies that this account can receive.
        /// </summary>
        [DataMember(Name = "receive_currencies")]
        public string[]? ReceiveCurrencies { get; set; }

        /// <summary>
        /// Array of Currency Codes for currencies that this account can send.
        /// </summary>
        [DataMember(Name = "send_currencies")]
        public string[]? SendCurrencies { get; set; }

        /// <summary>
        /// If true, this data comes from a validated ledger.
        /// </summary>
        [DataMember(Name = "validated")]
        public bool Validated { get; set; }
    }

    public class AccountCurrenciesResponse : ResponseBase<AccountCurrenciesResponseResult>
    {
    }
}