using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using XRPL.Core.Domain.Interfaces;
using XRPL.Core.Domain.Requests;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Clients
{
    /// <summary>
    /// Represents a JSON-RPC client that can send requests to a rippled server.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="JsonRpcClient"/> for the given endpoint.
    /// </remarks>
    /// <param name="uri">The URL of the rippled server to connect to.</param>
    /// <exception cref="ArgumentException"><paramref name="uri"/> is null.</exception>
    public class JsonRpcClient(Uri uri) : IDisposable
    {
        private const string contentType = "application/json";
        private readonly HttpClient client = new();
        private readonly Uri uri = uri ?? throw new ArgumentNullException(nameof(uri));
        private readonly Encoding encoding = new UTF8Encoding(false, true);

        /// <summary>
        /// The serializer options for the JSON serializer
        /// </summary>
        public JsonSerializerOptions? JsonSerializerOptions { get; set; }

        private bool disposedValue;

        private TResponse? Post<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : RequestBase, IExpect<TResponse>
            where TResponse : ResponseBase
        {
            var json = JsonSerializer.Serialize(request, JsonSerializerOptions);
            using var content = new StringContent(json, encoding, contentType);
            var message = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

            using var response = client.Send(message, cancellation);
            response.EnsureSuccessStatusCode();

            using var stream = response.Content.ReadAsStream(cancellation);
            return JsonSerializer.Deserialize<TResponse>(stream, JsonSerializerOptions);
        }

        private async Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : IExpect<TResponse>
            where TResponse : ResponseBase
        {
            using var response = await client
                .PostAsJsonAsync(uri, request, cancellation)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(cancellation);
            return await JsonSerializer
                .DeserializeAsync<TResponse>(stream, JsonSerializerOptions, cancellation)
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

        public AmmInfoResponse? Post(AmmInfoRequest request, CancellationToken cancellation)
            => Post<AmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public Task<AmmInfoResponse?> PostAsync(AmmInfoRequest request, CancellationToken cancellation)
            => PostAsync<AmmInfoRequest, AmmInfoResponse>(request, cancellation);

        public DepositAuthorizedResponse? Post(DepositAuthorizedRequest request, CancellationToken cancellation)
            => Post<DepositAuthorizedRequest, DepositAuthorizedResponse>(request, cancellation);

        public Task<DepositAuthorizedResponse?> PostAsync(DepositAuthorizedRequest request, CancellationToken cancellation)
            => PostAsync<DepositAuthorizedRequest, DepositAuthorizedResponse>(request, cancellation);

        public GatewayBalancesResponse? Post(GatewayBalancesRequest request, CancellationToken cancellation)
            => Post<GatewayBalancesRequest, GatewayBalancesResponse>(request, cancellation);

        public Task<GatewayBalancesResponse?> PostAsync(GatewayBalancesRequest request, CancellationToken cancellation)
            => PostAsync<GatewayBalancesRequest, GatewayBalancesResponse>(request, cancellation);

        public NFTBuyOffersResponse? Post(NFTBuyOffersRequest request, CancellationToken cancellation)
            => Post<NFTBuyOffersRequest, NFTBuyOffersResponse>(request, cancellation);

        public Task<NFTBuyOffersResponse?> PostAsync(NFTBuyOffersRequest request, CancellationToken cancellation)
            => PostAsync<NFTBuyOffersRequest, NFTBuyOffersResponse>(request, cancellation);

        public NFTSellOffersResponse? Post(NFTSellOffersRequest request, CancellationToken cancellation)
            => Post<NFTSellOffersRequest, NFTSellOffersResponse>(request, cancellation);

        public Task<NFTSellOffersResponse?> PostAsync(NFTSellOffersRequest request, CancellationToken cancellation)
            => PostAsync<NFTSellOffersRequest, NFTSellOffersResponse>(request, cancellation);

        public NoRippleCheckResponse? Post(NoRippleCheckRequest request, CancellationToken cancellation)
            => Post<NoRippleCheckRequest, NoRippleCheckResponse>(request, cancellation);

        public Task<NoRippleCheckResponse?> PostAsync(NoRippleCheckRequest request, CancellationToken cancellation)
            => PostAsync<NoRippleCheckRequest, NoRippleCheckResponse>(request, cancellation);

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

        public HashTxResponse? Post(TxRequest request, CancellationToken cancellation)
            => Post<TxRequest, HashTxResponse>(request, cancellation);

        public Task<HashTxResponse?> PostAsync(TxRequest request, CancellationToken cancellation)
            => PostAsync<TxRequest, HashTxResponse>(request, cancellation);

        public CtidTxResponse? Post(CtidTxRequest request, CancellationToken cancellation)
            => Post<CtidTxRequest, CtidTxResponse>(request, cancellation);

        public Task<CtidTxResponse?> PostAsync(CtidTxRequest request, CancellationToken cancellation)
            => PostAsync<CtidTxRequest, CtidTxResponse>(request, cancellation);

        public TxHistoryResponse? Post(TxHistoryRequest request, CancellationToken cancellation)
            => Post<TxHistoryRequest, TxHistoryResponse>(request, cancellation);

        public Task<TxHistoryResponse?> PostAsync(TxHistoryRequest request, CancellationToken cancellation)
            => PostAsync<TxHistoryRequest, TxHistoryResponse>(request, cancellation);

        #endregion Account Methods

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
