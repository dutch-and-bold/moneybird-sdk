using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Extensions;

namespace DutchAndBold.MoneybirdSdk
{
    public class MoneybirdClient : IMoneybirdClient
    {
        private readonly HttpClient _httpClient;

        public MoneybirdClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc cref="IMoneybirdClient"/>
        public async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(path, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await ParseResponse<T>(response, cancellationToken);
        }

        /// <inheritdoc cref="IMoneybirdClient"/>
        public async Task<T> PostAsync<T>(string path, HttpContent body, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsync(path, body, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await ParseResponse<T>(response, cancellationToken);
        }

        /// <summary>
        /// Reads an deserializes response stream.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="T"/></returns>
        private static async Task<T> ParseResponse<T>(
            HttpResponseMessage response,
            CancellationToken cancellationToken = default)
        {
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(
                responseStream,
                new JsonSerializerOptions().Moneybird(),
                cancellationToken);
        }
    }
}