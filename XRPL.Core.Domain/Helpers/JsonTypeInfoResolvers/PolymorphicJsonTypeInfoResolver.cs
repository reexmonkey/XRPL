using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using XRPL.Core.Domain.Entries;
using XRPL.Core.Domain.PseudoTransactions;
using XRPL.Core.Domain.Transactions;

namespace XRPL.Core.Domain.Helpers.JsonTypeInfoResolvers
{
    /// <summary>
    /// Defines the  reflection-based JSON contract resolver for XRPL types used by System.Text.Json.
    /// </summary>
    public class PolymorphicJsonTypeInfoResolver : DefaultJsonTypeInfoResolver
    {
        /// <summary>
        /// Resolves a JSON contract for a given type and options configuration.
        /// </summary>
        /// <param name="type">The type for which to resolve a JSON contract.</param>
        /// <param name="options">A <see cref="JsonSerializerOptions"/> instance used to determine contract configuration.</param>
        /// <returns>A <see cref="JsonTypeInfo"/> defining a reflection-derived JSON contract for type.</returns>
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var info = base.GetTypeInfo(type, options);

            if (info.Type == typeof(LedgerEntryBase))
                info.PolymorphismOptions = BuildLedgerEntryPolymorphismOptions();

            if (info.Type == typeof(PseudoTransaction))
                info.PolymorphismOptions = BuildPseudoTransactionPolymorphismOptions();

            if (info.Type == typeof(Transaction))
                info.PolymorphismOptions = BuildTransactionPolymorphismOptions();

            return info;
        }

        private static JsonPolymorphismOptions BuildLedgerEntryPolymorphismOptions()
        {
            return new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = nameof(LedgerEntryBase),
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = System.Text.Json.Serialization.JsonUnknownDerivedTypeHandling.FallBackToBaseType,
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(AccountRoot), nameof(AccountRoot)),
                    new JsonDerivedType(typeof(AmmAccountRoot), nameof(AmmAccountRoot)),
                    new JsonDerivedType(typeof(Ammendments), nameof(Ammendments)),
                    new JsonDerivedType(typeof(Bridge), nameof(Bridge)),
                    new JsonDerivedType(typeof(Check), nameof(Check)),
                    new JsonDerivedType(typeof(DepositPreauthEntry), nameof(DepositPreauthEntry)),
                    new JsonDerivedType(typeof(DID), nameof(DID)),
                    new JsonDerivedType(typeof(DirectoryNode), nameof(DirectoryNode)),
                    new JsonDerivedType(typeof(Escrow), nameof(Escrow)),
                    new JsonDerivedType(typeof(FeeSettings), nameof(FeeSettings)),
                    new JsonDerivedType(typeof(LedgerHashes), nameof(LedgerHashes)),
                    new JsonDerivedType(typeof(NegativeUNL), nameof(NegativeUNL)),
                    new JsonDerivedType(typeof(NFTokenOffer), nameof(NFTokenOffer)),
                    new JsonDerivedType(typeof(NFTokenPage), nameof(NFTokenPage)),
                    new JsonDerivedType(typeof(Offer), nameof(Offer)),
                    new JsonDerivedType(typeof(PayChannel), nameof(PayChannel)),
                    new JsonDerivedType(typeof(RippleState), nameof(RippleState)),
                    new JsonDerivedType(typeof(SignerList), nameof(SignerList)),
                    new JsonDerivedType(typeof(Ticket), nameof(Ticket)),
                    new JsonDerivedType(typeof(XChainOwnedClaimID), nameof(XChainOwnedClaimID)),
                    new JsonDerivedType(typeof(XChainOwnedCreateAccountClaimID), nameof(XChainOwnedCreateAccountClaimID)),
                }
            };
        }

        private static JsonPolymorphismOptions BuildPseudoTransactionPolymorphismOptions()
        {
            return new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = nameof(PseudoTransaction),
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = System.Text.Json.Serialization.JsonUnknownDerivedTypeHandling.FallBackToBaseType,
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(EnableAmendment), nameof(EnableAmendment)),
                    new JsonDerivedType(typeof(SetFee), nameof(SetFee)),
                    new JsonDerivedType(typeof(LastestSetFee), nameof(LastestSetFee)),
                    new JsonDerivedType(typeof(UNLModify), nameof(UNLModify))
                }
            };
        }

        private static JsonPolymorphismOptions BuildTransactionPolymorphismOptions()
        {
            return new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = nameof(Transaction),
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = System.Text.Json.Serialization.JsonUnknownDerivedTypeHandling.FallBackToBaseType,
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(AccountDelete), nameof(AccountDelete)),
                    new JsonDerivedType(typeof(AccountSet), nameof(AccountSet)),
                    new JsonDerivedType(typeof(AMMBid), nameof(AMMBid)),
                    new JsonDerivedType(typeof(AMMCreate), nameof(AMMCreate)),
                    new JsonDerivedType(typeof(AMMDelete), nameof(AMMDelete)),
                    new JsonDerivedType(typeof(AMMDeposit), nameof(AMMDeposit)),
                    new JsonDerivedType(typeof(AMMVote), nameof(AMMVote)),
                    new JsonDerivedType(typeof(AMMWithdraw), nameof(AMMWithdraw)),
                    new JsonDerivedType(typeof(CheckCancel), nameof(CheckCancel)),
                    new JsonDerivedType(typeof(CheckCash), nameof(CheckCash)),
                    new JsonDerivedType(typeof(CheckCreate), nameof(CheckCreate)),
                    new JsonDerivedType(typeof(Clawback), nameof(Clawback)),
                    new JsonDerivedType(typeof(DepositPreauth), nameof(DepositPreauth)),
                    new JsonDerivedType(typeof(DIDDelete), nameof(DIDDelete)),
                    new JsonDerivedType(typeof(DIDSet), nameof(DIDSet)),
                    new JsonDerivedType(typeof(EscrowCancel), nameof(EscrowCancel)),
                    new JsonDerivedType(typeof(EscrowCreate), nameof(EscrowCreate)),
                    new JsonDerivedType(typeof(EscrowFinish), nameof(EscrowFinish)),
                    new JsonDerivedType(typeof(BrokeredModeNFTokenAcceptOffer), nameof(BrokeredModeNFTokenAcceptOffer)),
                    new JsonDerivedType(typeof(NFTokenBurn), nameof(NFTokenBurn)),
                    new JsonDerivedType(typeof(NFTokenCancelOffer), nameof(NFTokenCancelOffer)),
                    new JsonDerivedType(typeof(NFTokenCreateOffer), nameof(NFTokenCreateOffer)),
                    new JsonDerivedType(typeof(NFTokenMint), nameof(NFTokenMint)),
                    new JsonDerivedType(typeof(OfferCancel), nameof(OfferCancel)),
                    new JsonDerivedType(typeof(OfferCreate), nameof(OfferCreate)),
                    new JsonDerivedType(typeof(Payment), nameof(Payment)),
                    new JsonDerivedType(typeof(PaymentChannelClaim), nameof(PaymentChannelClaim)),
                    new JsonDerivedType(typeof(PaymentChannelFund), nameof(PaymentChannelFund)),
                    new JsonDerivedType(typeof(SetRegularKey), nameof(SetRegularKey)),
                    new JsonDerivedType(typeof(SignerListSet), nameof(SignerList)),
                    new JsonDerivedType(typeof(TicketCreate), nameof(TicketCreate)),
                    new JsonDerivedType(typeof(TrustSet), nameof(TrustSet)),
                    new JsonDerivedType(typeof(XChainAccountCreateCommit), nameof(XChainAccountCreateCommit)),
                }
            };
        }
    }
}
