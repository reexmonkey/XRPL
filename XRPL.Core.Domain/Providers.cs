using System.Text.Json.Serialization.Metadata;
using XRPL.Core.Domain.Contexts;
using XRPL.Core.Domain.Entries;

namespace XRPL.Core.Domain
{
    public static class Providers
    {
        public static IJsonTypeInfoResolver[] GetResolvers()
        {
            return
            [
                //LedgerEntry resolvers
                CheckContext.Default,
                NFTokenOfferContext.Default,
                OfferContext.Default,

                //TransactionResolvers
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
                TransactionMetadataContext.Default

            ];
        }

    }
}
