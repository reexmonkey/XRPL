using System.Text.Json.Serialization;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that sets aside one or more sequence numbers as Tickets.
    /// </summary>
    [JsonDerivedType(typeof(TicketCreate), typeDiscriminator: nameof(TicketCreate))]
    public class TicketCreate : Transaction
    {
        /// <summary>
        /// How many Tickets to create. 
        /// <para/>This must be a positive number and cannot cause the account to own more than 250 Tickets after executing this transaction.
        /// </summary>
        public required uint TicketCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketCreate"/> class.
        /// </summary>
        public TicketCreate() : base(TransactionType.TicketCreate)
        {
        }
    }
}