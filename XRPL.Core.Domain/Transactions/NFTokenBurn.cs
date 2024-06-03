using System.Text.Json.Serialization;
using XRPL.Core.Domain.Models;

namespace XRPL.Core.Domain.Transactions
{
    /// <summary>
    /// Represents a transaction to remove a NFToken object from the NFTokenPage in which it is being held,
    /// effectively removing the token from the ledger (burning it).
    /// <para/>The sender of this transaction must be the owner of the NFToken to burn;
    /// or, if the NFToken has the lsfBurnable flag enabled, can be the issuer or the issuer's authorized NFTokenMinter account instead.
    /// <para/>If this operation succeeds, the corresponding NFToken is removed.
    /// If this operation empties the NFTokenPage holding the NFToken or results in consolidation,
    /// thus removing a NFTokenPage, the owner’s reserve requirement is reduced by one.
    /// </summary>
    [JsonDerivedType(typeof(NFTokenBurn), typeDiscriminator: nameof(NFTokenBurn))]
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
