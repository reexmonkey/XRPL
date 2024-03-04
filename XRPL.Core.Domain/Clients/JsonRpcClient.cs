using ServiceStack;
using System.Net.Http.Headers;
using System.Text;
using XRPL.Core.Domain.Requests;
using XRPL.Core.Domain.Responses;

namespace XRPL.Core.Domain.Clients
{
    /// <summary>
    /// Represents a JSON-RPC client that can send requests to a rippled server.
    /// </summary>
    public class JsonRpcClient : IDisposable
    {
        private const string contentType = "application/json";
        private readonly HttpClient client;
        private readonly Uri uri;
        private readonly Encoding encoding;

        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcClient"/> for the given endpoint.
        /// </summary>
        /// <param name="url">The URL of the rippled server to connect to.</param>
        /// <exception cref="ArgumentException"><paramref name="url"/> is null.</exception>
        public JsonRpcClient(Uri uri)
        {
            this.uri = uri ?? throw new ArgumentNullException(nameof(uri));
            client = new HttpClient();
            encoding = new UTF8Encoding(false, true);
        }

        private TResponse Post<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
            where TRequest : class
            where TResponse : class
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            var message = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

            using var response = client.Send(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            using var reader = new StreamReader(response.Content.ReadAsStream(cancellationToken));
            var result = reader.ReadToEnd();
            return result.FromJson<TResponse>();
        }

        private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            using var response = await client.PostAsync(uri, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            return result.FromJson<TResponse>();
        }

        #region Account Methods

        public AccountChannelsResponse Post(AccountChannelsRequest request, CancellationToken cancellationToken)
            => Post<AccountChannelsRequest, AccountChannelsResponse>(request, cancellationToken);

        public Task<AccountChannelsResponse> PostAsync(AccountChannelsRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountChannelsRequest, AccountChannelsResponse>(request, cancellationToken);

        public AccountCurrenciesResponse Post(AccountCurrenciesRequest request, CancellationToken cancellationToken)
            => Post<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellationToken);

        public Task<AccountCurrenciesResponse> PostAsync(AccountCurrenciesRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellationToken);

        public Task<AccountInfoResponse> PostAsync(AccountInfoRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountInfoRequest, AccountInfoResponse>(request, cancellationToken);

        public Task<AccountLinesResponse> PostAsync(AccountLinesRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountLinesRequest, AccountLinesResponse>(request, cancellationToken);

        public Task<AccountNFTsResponse> PostAsync(AccountNFTsRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountNFTsRequest, AccountNFTsResponse>(request, cancellationToken);

        public Task<AccountObjectsResponse> PostAsync(AccountObjectsRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountObjectsRequest, AccountObjectsResponse>(request, cancellationToken);

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