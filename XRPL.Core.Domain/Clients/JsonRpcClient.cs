using System.Text;
using System.Text.Json;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Methods;
using XRPL.Core.Domain.Methods.AccountMethods.AccountChannels;
using XRPL.Core.Domain.Methods.AccountMethods.AccountCurrencies;
using XRPL.Core.Domain.Methods.AccountMethods.AccountInfo;
using XRPL.Core.Domain.Methods.AccountMethods.AccountLines;
using XRPL.Core.Domain.Methods.AccountMethods.AccountNFTs;
using XRPL.Core.Domain.Methods.AccountMethods.AccountObjects;
using XRPL.Core.Domain.Methods.AccountMethods.AccountTx;
using XRPL.Core.Domain.Methods.AccountMethods.GatewayBalances;
using XRPL.Core.Domain.Methods.AccountMethods.NoRippleCheck;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.AmmInfo;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.BookOffers;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.DepositAuthorized;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.NftBuyOffers;
using XRPL.Core.Domain.Methods.PathAndOrderBookMethods.NftSellOffers;
using XRPL.Core.Domain.Methods.TransactionMethods.Submit;
using XRPL.Core.Domain.Methods.TransactionMethods.SubmitMultisigned;
using XRPL.Core.Domain.Methods.TransactionMethods.TransactionEntry;
using XRPL.Core.Domain.Methods.TransactionMethods.Tx;
using XRPL.Core.Domain.Methods.TransactionMethods.TxHistory;

namespace XRPL.Core.Domain.Clients
{
    /// <summary>
    /// Represents a JSON-RPC client that can send requests to a rippled server.
    /// </summary>
    public class JsonRpcClient : IDisposable
    {
        private const string contentType = "application/json";
        private readonly HttpClient client = new();
        private readonly Uri uri;
        private readonly Encoding encoding = new UTF8Encoding(false, true);

        private static readonly JsonSerializerOptions serializerOptions = new()
        {
            WriteIndented = true,
        };

        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcClient"/> for the given endpoint.
        /// </summary>
        /// <param name="uri">The URL of the rippled server to connect to</param>
        /// <exception cref="ArgumentException"><paramref name="uri"/> is null.</exception>
        public JsonRpcClient(Uri uri)
        {
            this.uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        private TResponse? Post<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : RequestBase, IExpect<TResponse>
            where TResponse : ResponseBase
        {
            var json = JsonSerializer.Serialize(request, serializerOptions);
            using var content = new StringContent(json, encoding, contentType);
            var message = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

            using var response = client.Send(message, cancellation);
            response.EnsureSuccessStatusCode();

            using var stream = response.Content.ReadAsStream(cancellation);
            return JsonSerializer.Deserialize<TResponse>(stream, serializerOptions);
        }

        private async Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : IExpect<TResponse>
            where TResponse : ResponseBase
        {
            using var requestStream = new MemoryStream();
            await JsonSerializer
                .SerializeAsync(requestStream, request, serializerOptions, cancellation)
                .ConfigureAwait(false);

            requestStream.Position = 0;

            using var content = new StreamContent(requestStream);
            using var response = await client
                .PostAsync(uri, content, cancellation)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content
                .ReadAsStreamAsync(cancellation)
                .ConfigureAwait(false);

            return await JsonSerializer
                .DeserializeAsync<TResponse>(responseStream, serializerOptions, cancellation)
                .ConfigureAwait(false);
        }

        #region Account Methods

        public AccountChannelsResponse? Post(AccountChannelsRequest request, CancellationToken cancellation)
            => Post<AccountChannelsRequest, AccountChannelsResponse>(request, cancellation);

        public Task<AccountChannelsResponse?> PostAsync(AccountChannelsRequest request, CancellationToken cancellation)
            => PostAsync<AccountChannelsRequest, AccountChannelsResponse>(request, cancellation);

        public AccountCurrenciesResponse? Post(AccountCurrenciesRequest request, CancellationToken cancellation)
            => Post<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellation);

        public Task<AccountCurrenciesResponse?> PostAsync(AccountCurrenciesRequest request, CancellationToken cancellation)
            => PostAsync<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellation);

        public AccountInfoResponse? Post(AccountInfoRequest request, CancellationToken cancellation)
            => Post<AccountInfoRequest, AccountInfoResponse>(request, cancellation);

        public Task<AccountInfoResponse?> PostAsync(AccountInfoRequest request, CancellationToken cancellation)
            => PostAsync<AccountInfoRequest, AccountInfoResponse>(request, cancellation);

        public AccountLinesResponse? Post(AccountLinesRequest request, CancellationToken cancellation)
            => Post<AccountLinesRequest, AccountLinesResponse>(request, cancellation);

        public Task<AccountLinesResponse?> PostAsync(AccountLinesRequest request, CancellationToken cancellation)
            => PostAsync<AccountLinesRequest, AccountLinesResponse>(request, cancellation);

        public AccountNFTsResponse? Post(AccountNFTsRequest request, CancellationToken cancellation)
            => Post<AccountNFTsRequest, AccountNFTsResponse>(request, cancellation);

        public Task<AccountNFTsResponse?> PostAsync(AccountNFTsRequest request, CancellationToken cancellation)
            => PostAsync<AccountNFTsRequest, AccountNFTsResponse>(request, cancellation);

        public AccountObjectsResponse? Post(AccountObjectsRequest request, CancellationToken cancellation)
            => Post<AccountObjectsRequest, AccountObjectsResponse>(request, cancellation);

        public Task<AccountObjectsResponse?> PostAsync(AccountObjectsRequest request, CancellationToken cancellation)
            => PostAsync<AccountObjectsRequest, AccountObjectsResponse>(request, cancellation);

        public AccountTxResponse? Post(AccountTxRequest request, CancellationToken cancellation)
            => Post<AccountTxRequest, AccountTxResponse>(request, cancellation);

        public Task<AccountTxResponse?> PostAsync(AccountTxRequest request, CancellationToken cancellation)
            => PostAsync<AccountTxRequest, AccountTxResponse>(request, cancellation);

        public NoRippleCheckResponse? Post(NoRippleCheckRequest request, CancellationToken cancellation)
    => Post<NoRippleCheckRequest, NoRippleCheckResponse>(request, cancellation);

        public Task<NoRippleCheckResponse?> PostAsync(NoRippleCheckRequest request, CancellationToken cancellation)
            => PostAsync<NoRippleCheckRequest, NoRippleCheckResponse>(request, cancellation);

        #endregion Account Methods

        #region Path and Order Book Methods

        public AmmInfoResponse? Post(AccountAmmInfoRequest request, CancellationToken cancellation)
    => Post<AccountAmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public Task<AmmInfoResponse?> PostAsync(AccountAmmInfoRequest request, CancellationToken cancellation)
            => PostAsync<AccountAmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public AmmInfoResponse? Post(AssetAmmInfoRequest request, CancellationToken cancellation)
            => Post<AssetAmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public Task<AmmInfoResponse?> PostAsync(AssetAmmInfoRequest request, CancellationToken cancellation)
            => PostAsync<AssetAmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public BookOffersResponse? Post(BookOffersRequest request, CancellationToken cancellation)
            => Post<BookOffersRequest, BookOffersResponse>(request, cancellation);

        public Task<BookOffersResponse?> PostAsync(BookOffersRequest request, CancellationToken cancellation)
            => PostAsync<BookOffersRequest, BookOffersResponse>(request, cancellation);

        public DepositAuthorizedResponse? Post(DepositAuthorizedRequest request, CancellationToken cancellation)
            => Post<DepositAuthorizedRequest, DepositAuthorizedResponse>(request, cancellation);

        public Task<DepositAuthorizedResponse?> PostAsync(DepositAuthorizedRequest request, CancellationToken cancellation)
            => PostAsync<DepositAuthorizedRequest, DepositAuthorizedResponse>(request, cancellation);

        public GatewayBalancesResponse? Post(GatewayBalancesRequest request, CancellationToken cancellation)
            => Post<GatewayBalancesRequest, GatewayBalancesResponse>(request, cancellation);

        public Task<GatewayBalancesResponse?> PostAsync(GatewayBalancesRequest request, CancellationToken cancellation)
            => PostAsync<GatewayBalancesRequest, GatewayBalancesResponse>(request, cancellation);

        public NftBuyOffersResponse? Post(NftBuyOffersRequest request, CancellationToken cancellation)
            => Post<NftBuyOffersRequest, NftBuyOffersResponse>(request, cancellation);

        public Task<NftBuyOffersResponse?> PostAsync(NftBuyOffersRequest request, CancellationToken cancellation)
            => PostAsync<NftBuyOffersRequest, NftBuyOffersResponse>(request, cancellation);

        public NftSellOffersResponse? Post(NftSellOffersRequest request, CancellationToken cancellation)
            => Post<NftSellOffersRequest, NftSellOffersResponse>(request, cancellation);

        public Task<NftSellOffersResponse?> PostAsync(NftSellOffersRequest request, CancellationToken cancellation)
            => PostAsync<NftSellOffersRequest, NftSellOffersResponse>(request, cancellation);

        #endregion Path and Order Book Methods

        #region Transaction Methods

        public SubmitMultisignedResponse? Post(SubmitMultisignedRequest request, CancellationToken cancellation)
               => Post<SubmitMultisignedRequest, SubmitMultisignedResponse>(request, cancellation);

        public Task<SubmitMultisignedResponse?> PostAsync(SubmitMultisignedRequest request, CancellationToken cancellation)
            => PostAsync<SubmitMultisignedRequest, SubmitMultisignedResponse>(request, cancellation);

        public SubmitResponse? Post(SubmitOnlyRequest request, CancellationToken cancellation)
            => Post<SubmitOnlyRequest, SubmitResponse>(request, cancellation);

        public Task<SubmitResponse?> PostAsync(SubmitOnlyRequest request, CancellationToken cancellation)
            => PostAsync<SubmitOnlyRequest, SubmitResponse>(request, cancellation);

        public SubmitResponse? Post(SignAndSubmitRequest request, CancellationToken cancellation)
            => Post<SignAndSubmitRequest, SubmitResponse>(request, cancellation);

        public Task<SubmitResponse?> PostAsync(SignAndSubmitRequest request, CancellationToken cancellation)
            => PostAsync<SignAndSubmitRequest, SubmitResponse>(request, cancellation);

        public TransactionEntryResponse? Post(TransactionEntryRequest request, CancellationToken cancellation)
            => Post<TransactionEntryRequest, TransactionEntryResponse>(request, cancellation);

        public Task<TransactionEntryResponse?> PostAsync(TransactionEntryRequest request, CancellationToken cancellation)
            => PostAsync<TransactionEntryRequest, TransactionEntryResponse>(request, cancellation);

        public HashJsonTxResponse? Post(HashJsonTxRequest request, CancellationToken cancellation)
            => Post<HashJsonTxRequest, HashJsonTxResponse>(request, cancellation);

        public Task<HashJsonTxResponse?> PostAsync(HashJsonTxRequest request, CancellationToken cancellation)
            => PostAsync<HashJsonTxRequest, HashJsonTxResponse>(request, cancellation);

        public CtidJsonTxResponse? Post(CtidJsonTxRequest request, CancellationToken cancellation)
            => Post<CtidJsonTxRequest, CtidJsonTxResponse>(request, cancellation);

        public Task<CtidJsonTxResponse?> PostAsync(CtidJsonTxRequest request, CancellationToken cancellation)
            => PostAsync<CtidJsonTxRequest, CtidJsonTxResponse>(request, cancellation);

        public CtidBinaryTxResponse? Post(CtidBinaryTxRequest request, CancellationToken cancellation)
            => Post<CtidBinaryTxRequest, CtidBinaryTxResponse>(request, cancellation);

        public Task<CtidBinaryTxResponse?> PostAsync(CtidBinaryTxRequest request, CancellationToken cancellation)
            => PostAsync<CtidBinaryTxRequest, CtidBinaryTxResponse>(request, cancellation);

        public HashBinaryTxResponse? Post(HashBinaryTxRequest request, CancellationToken cancellation)
            => Post<HashBinaryTxRequest, HashBinaryTxResponse>(request, cancellation);

        public Task<HashBinaryTxResponse?> PostAsync(HashBinaryTxRequest request, CancellationToken cancellation)
            => PostAsync<HashBinaryTxRequest, HashBinaryTxResponse>(request, cancellation);

        public TxHistoryResponse? Post(TxHistoryRequest request, CancellationToken cancellation)
            => Post<TxHistoryRequest, TxHistoryResponse>(request, cancellation);

        public Task<TxHistoryResponse?> PostAsync(TxHistoryRequest request, CancellationToken cancellation)
            => PostAsync<TxHistoryRequest, TxHistoryResponse>(request, cancellation);

        #endregion Transaction Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) client.Dispose();
                disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes the resources of the JsonRpcClient.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
