using System.Net.Http.Json;
using System.Text.Json;
using XRPL.Core.Domain.Methods.JsonRpc.AccountMethods;

namespace XRPL.Core.Domain.Clients
{
    /// <summary>
    /// Represents a JSON-RPC client that can send requests to a rippled server.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="JsonRpcClient"/> for the given endpoint.</remarks>
    /// <param name="url">The URL of the rippled server to connect to.</param>
    /// <exception cref="ArgumentException"><paramref name="url"/> is null.</exception>
    public class JsonRpcClient(Uri uri) : IDisposable
    {
        private readonly HttpClient client = new();
        private readonly Uri uri = uri ?? throw new ArgumentNullException(nameof(uri));

        private bool disposedValue;

        private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        {
            using var response = await client.PostAsJsonAsync(uri, request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<TResponse>(result)
                ?? throw new JsonException($"Unable to deserialize response to type {typeof(TResponse).FullName}");
        }

        #region Account Methods

        /// <summary>
        /// Submits an asynchronous request to create or update account channels on the XRPL network.
        /// </summary>
        /// <remarks>This method enables non-blocking processing of account channel requests, allowing applications to maintain responsiveness while awaiting results.</remarks>
        /// <param name="request">The request object containing the details for the account channels operation. Cannot be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response with account channels information.</returns>
        public Task<AccountChannelsResponse> PostAsync(AccountChannelsRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountChannelsRequest, AccountChannelsResponse>(request, cancellationToken);

        /// <summary>
        /// Submits an asynchronous request to retrieve account currencies based on the specified parameters.
        /// </summary>
        /// <remarks>Ensure that the request object is properly populated before calling this method. This method is intended for scenarios where account currencies need to be fetched asynchronously.</remarks>
        /// <param name="request">The request object containing the parameters required to fetch account currencies. Cannot be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an AccountCurrenciesResponse with the account currencies data.</returns>
        public Task<AccountCurrenciesResponse> PostAsync(AccountCurrenciesRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountCurrenciesRequest, AccountCurrenciesResponse>(request, cancellationToken);

        /// <summary>
        /// Submits an asynchronous request to retrieve account information based on the provided request parameters.
        /// </summary>
        /// <remarks>
        /// This method is designed to be called when account information needs to be retrieved asynchronously. Ensure that the request object is properly populated before calling this method.
        /// </remarks>
        /// <param name="request">The request object containing the necessary parameters to fetch account information. Must not be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, containing the account information response upon completion.</returns>
        public Task<AccountInfoResponse> PostAsync(AccountInfoRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountInfoRequest, AccountInfoResponse>(request, cancellationToken);

        /// <summary>
        /// Submits an asynchronous request to retrieve account lines based on the specified criteria.
        /// </summary>
        /// <remarks>This method is designed to be called when the user needs to fetch account lines asynchronously. Ensure that the request is properly populated before calling this method.</remarks>
        /// <param name="request">The request object containing the parameters for the account lines query. Must not be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation, containing the response with account lines data.</returns>
        public Task<AccountLinesResponse> PostAsync(AccountLinesRequest request, CancellationToken cancellationToken)
            => PostAsync<AccountLinesRequest, AccountLinesResponse>(request, cancellationToken);

        #endregion Account Methods

        /// <summary>
        /// Releases the resources used by the current instance of the class. This method can be called explicitly to free up resources immediately.
        /// </summary>
        /// <remarks>This method is part of the IDisposable interface implementation and should be called when the object is no longer needed to ensure proper resource management.</remarks>
        /// <param name="disposing">
        /// Indicates whether the method was called directly or by the garbage collector. If <see langword="true"/>, the method releases both managed and unmanaged resources; if <see
        /// langword="false"/>, it releases only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    client.Dispose();
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance of the class.
        /// </summary>
        /// <remarks>
        /// Call this method when the object is no longer needed to free unmanaged and managed resources deterministically. After calling Dispose, the object should not be used further. This method
        /// suppresses finalization to optimize resource cleanup.
        /// </remarks>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}