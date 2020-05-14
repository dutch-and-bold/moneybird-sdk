using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;

namespace DutchAndBold.MoneybirdSdk
{
    public class MoneybirdClient : IMoneybirdClient
    {
        private readonly HttpClient _httpClient;

        public MoneybirdClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
            where T : class
        {
            var response = await _httpClient.GetAsync(path, cancellationToken);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream, null, cancellationToken);
        }
    }
}