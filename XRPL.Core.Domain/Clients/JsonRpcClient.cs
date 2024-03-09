using ServiceStack;
using System.Net.Http.Headers;
using System.Text;
using XRPL.Core.Domain.Contracts;
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
    /// <param name="url">The URL of the rippled server to connect to.</param>
    /// <exception cref="ArgumentException"><paramref name="url"/> is null.</exception>
    public class JsonRpcClient(Uri uri) : IDisposable
    {
        private const string contentType = "application/json";
        private readonly HttpClient client = new();
        private readonly Uri uri = uri ?? throw new ArgumentNullException(nameof(uri));
        private readonly Encoding encoding = new UTF8Encoding(false, true);

        private bool disposedValue;

        private TResponse Post<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : RequestBase, IRelateTo<TResponse>
            where TResponse : ResponseBase
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            var message = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

            using var response = client.Send(message, cancellation);
            response.EnsureSuccessStatusCode();

            using var reader = new StreamReader(response.Content.ReadAsStream(cancellation));
            var result = reader.ReadToEnd();
            return result.FromJson<TResponse>();
        }

        private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellation)
            where TRequest : IRelateTo<TResponse>
            where TResponse : ResponseBase
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            using var response = await client.PostAsync(uri, content, cancellation);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellation);
            return result.FromJson<TResponse>();
        }

        #region Account Methods

        public AccountChannelsResponse Post(AccountChannelsRequest request, CancellationToken cancellation)
            => Post<AccountChannelsRequest, AccountChannelsResponse>(request, cancellation);

        public Task<AccountChannelsResponse> PostAsync(AccountChannelsRequest request, CancellationToken cancellation)
            => PostAsync<AccountChannelsRequest, AccountChannelsResponse>(request, cancellation);

        public AccountCurrenciesResponse Post(AccountCurrenciesRequest request, CancellationToken cancellation)
            => Post<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellation);

        public Task<AccountCurrenciesResponse> PostAsync(AccountCurrenciesRequest request, CancellationToken cancellation)
            => PostAsync<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellation);

        public AccountInfoResponse Post(AccountInfoRequest request, CancellationToken cancellation)
            => Post<AccountInfoRequest, AccountInfoResponse>(request, cancellation);

        public Task<AccountInfoResponse> PostAsync(AccountInfoRequest request, CancellationToken cancellation)
            => PostAsync<AccountInfoRequest, AccountInfoResponse>(request, cancellation);

        public AccountLinesResponse Post(AccountLinesRequest request, CancellationToken cancellation)
            => Post<AccountLinesRequest, AccountLinesResponse>(request, cancellation);

        public Task<AccountLinesResponse> PostAsync(AccountLinesRequest request, CancellationToken cancellation)
            => PostAsync<AccountLinesRequest, AccountLinesResponse>(request, cancellation);

        public AccountNFTsResponse Post(AccountNFTsRequest request, CancellationToken cancellation)
            => Post<AccountNFTsRequest, AccountNFTsResponse>(request, cancellation);

        public Task<AccountNFTsResponse> PostAsync(AccountNFTsRequest request, CancellationToken cancellation)
            => PostAsync<AccountNFTsRequest, AccountNFTsResponse>(request, cancellation);

        public AccountObjectsResponse Post(AccountObjectsRequest request, CancellationToken cancellation)
            => Post<AccountObjectsRequest, AccountObjectsResponse>(request, cancellation);

        public Task<AccountObjectsResponse> PostAsync(AccountObjectsRequest request, CancellationToken cancellation)
            => PostAsync<AccountObjectsRequest, AccountObjectsResponse>(request, cancellation);

        public AccountTxResponse Post(AccountTxRequest request, CancellationToken cancellation)
            => Post<AccountTxRequest, AccountTxResponse>(request, cancellation);

        public Task<AccountTxResponse> PostAsync(AccountTxRequest request, CancellationToken cancellation)
            => PostAsync<AccountTxRequest, AccountTxResponse>(request, cancellation);

        #endregion Account Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    client.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~JsonRpcClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}