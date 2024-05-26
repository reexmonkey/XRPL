using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Specifies a transaction that creates either a new Sell offer for an <see cref="NFToken"/> owned by the account executing the transaction, 
    /// or a new Buy offer for an <see cref="NFToken"/> owned by another account.
    /// <para/>If successful, the transaction creates a <see cref="NFToken"/> object. 
    /// Each offer counts as one object towards the owner reserve of the account that placed the offer.
    /// </summary>
    public abstract class NFTokenCreateOffer : Transaction
    {
        /// <summary>
        /// (Optional) Who owns the corresponding NFToken. If the offer is to buy a token, this field must be present and it must be different than the Account field (since an offer to buy a token one already holds is meaningless). If the offer is to sell a token, this field must not be present, as the owner is, implicitly, the same as the Account (since an offer to sell a token one doesn't already hold is meaningless).
        /// </summary>
        public string? Owner { get; set; }

        /// <summary>
        /// Identifies the NFToken object that the offer references.
        /// </summary>
        public required string NFTokenID { get; set; }

        /// <summary>
        /// (Optional) Time after which the offer is no longer active, in seconds since the Ripple Epoch.
        /// </summary>
        public uint? Expiration { get; set; }

        /// <summary>
        /// (Optional) If present, indicates that this offer may only be accepted by the specified account. Attempts by other accounts to accept this offer MUST fail.
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NFTokenCreateOffer"/> class.
        /// </summary>
        public NFTokenCreateOffer() : base(TransactionType.NFTokenCreateOffer)
        {
        }
    }

    /// <summary>
    /// Specifies a transaction that creates either a new Sell offer for an <see cref="NFToken"/> owned by the account executing the transaction, 
    /// or a new Buy offer for an <see cref="NFToken"/> owned by another account.
    /// <para/>If successful, the transaction creates a <see cref="NFToken"/> object. 
    /// Each offer counts as one object towards the owner reserve of the account that placed the offer.
    /// </summary>
    /// <typeparam name="TAmount">The type of amount expected or offered for the corresponding <see cref="NFToken"/></typeparam>
    public abstract class NFTokenCreateOffer<TAmount> : NFTokenCreateOffer
        where TAmount : class
    {
        /// <summary>
        /// Indicates the amount expected or offered for the corresponding <see cref="NFToken"/>. 
        /// <para/>The amount must be non-zero, except where this is an offer to sell and the asset is XRP; then, it is legal to specify an amount of zero, which means that the current owner of the token is giving it away, gratis, either to anyone at all, or to the account identified by the Destination field.
        /// </summary>
        public required TAmount Amount { get; set; }
    }


    /// <summary>
    /// Represents a transaction that creates either a new Sell offer for an <see cref="NFToken"/> owned by the account executing the transaction, 
    /// or a new Buy offer for an <see cref="NFToken"/> owned by another account.
    /// <para/>If successful, the transaction creates a <see cref="NFToken"/> object. 
    /// Each offer counts as one object towards the owner reserve of the account that placed the offer.
    /// <para/>The asset expected or offered for the corresponding <see cref="NFToken"/> is XRP.
    /// </summary>
    public sealed class XrpNFTokenCreateOffer : NFTokenCreateOffer<string>
    {

    }

    /// <summary>
    /// Represents a transaction that creates either a new Sell offer for an <see cref="NFToken"/> owned by the account executing the transaction, 
    /// or a new Buy offer for an <see cref="NFToken"/> owned by another account.
    /// <para/>If successful, the transaction creates a <see cref="NFToken"/> object. 
    /// Each offer counts as one object towards the owner reserve of the account that placed the offer.
    /// <para/>The asset expected or offered for the corresponding <see cref="NFToken"/> is a fungible token.
    /// </summary>
    public sealed class FungibleTokenNFTokenCreateOffer : NFTokenCreateOffer<TokenAmount>
    {

    }

}