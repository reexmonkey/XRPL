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

        #region Account Methods

        public AccountChannelsResponse Post(AccountChannelsRequest request, CancellationToken cancellationToken)
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            var message = new HttpRequestMessage(HttpMethod.Post, uri) { Content = content };

            using var response = client.Send(message, cancellationToken);
            response.EnsureSuccessStatusCode();

            using var reader = new StreamReader(response.Content.ReadAsStream(cancellationToken));
            var result = reader.ReadToEnd();

            return result.FromJson<AccountChannelsResponse>();
        }

        public async Task<AccountChannelsResponse> PostAsync(AccountChannelsRequest request, CancellationToken cancellationToken)
        {
            var json = request.ToJson();

            using var content = new StringContent(json, encoding, contentType);
            using var response = await client.PostAsync(uri, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            return result.FromJson<AccountChannelsResponse>();
        }

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