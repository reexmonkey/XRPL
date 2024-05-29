using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction that is used to cancel existing token offers created using <see cref="NFTokenCreateOffer"/>.
    /// </summary>
    public abstract class NFTokenCancelOffer : Transaction
    {
        /// <summary>
        /// An array of IDs of the <see cref="NFTokenOffer"/> objects to cancel 
        /// (not the IDs of NFToken objects, but the IDs of the <see cref="NFTokenOffer"/> objects). 
        ///<para/>Each entry must be a different object ID of an <see cref="NFTokenOffer"/> object; 
        ///the transaction is invalid if the array contains duplicate entries.
        /// </summary>
        public required NFTokenOffer[] NFTokenSellOffer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenCancelOffer"/> class.
        /// </summary>
        public NFTokenCancelOffer() : base(TransactionType.NFTokenCancelOffer)
        {
        }
    }
}