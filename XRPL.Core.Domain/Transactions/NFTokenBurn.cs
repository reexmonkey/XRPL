using XRPL.Core.Domain.Models;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Transactions
{
    public class NFTokenBurn : Transaction
    {
        /// <summary>
        /// The <see cref="NFToken"/> to be removed by this transaction.
        /// </summary>
        public required string NFTokenID { get; set; }

        /// <summary>
        /// (Optional) The owner of the <see cref="NFToken"/> to burn. 
        /// <para/>Only used if that owner is different than the account sending this transaction. 
        /// The issuer or authorized minter can use this field to burn NFTs that have the lsfCancelOfferable flag enabled.
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenBurn"/> class.
        /// </summary>
        public NFTokenBurn() : base(TransactionType.NFTokenBurn)
        {
        }
    }
}