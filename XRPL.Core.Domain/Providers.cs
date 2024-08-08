using System.Text.Json.Serialization.Metadata;
using XRPL.Core.Domain.SerializerContexts;

namespace XRPL.Core.Domain
{
    public static class Providers
    {
        public static IJsonTypeInfoResolver[] GetResolvers()
        {
            return
            [
                //Ledger Entry resolvers
                CheckContext.Default,
                NFTokenOfferContext.Default,
                OfferContext.Default,

                //Account Method resolvers
                AccountObjectsResultContext.Default,
                AccountOfferContext.Default,
                AccountOfferContext.Default,
                NoRippleCheckResultContext.Default,

                //Path and Order Book Method resolvers
                AssetAmmInfoParametersContext.Default,
                RipplePathFindParametersContext.Default,
                RiplePathFindResultContext.Default,
                AlternativePathContext.Default,

                //Transaction resolvers
                AMMCreateContext.Default,
                AMMDepositContext.Default,
                AMMWithdrawContext.Default,
                CheckCashContext.Default,
                CheckCreateContext.Default,
                BrokeredModeNFTokenAcceptOfferContext.Default,
                NFTokenCreateOfferContext.Default,
                OfferCreateContext.Default,
                PaymentV1Context.Default,
                PaymentV2Context.Default,
                TransactionMetadataContext.Default,

                //Transaction Method resolvers
                SubmitResultContext.Default,
                SubmitMultisignedResultContext.Default,
                TransactionEntryResultContext.Default,
                TxResultContext.Default,
                JsonTxResultContext.Default
            ];
        }
    }
}
