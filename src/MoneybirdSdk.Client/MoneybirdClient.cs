using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneybirdSdk.Client
{
    public class MoneybirdClient
    {
        private readonly HttpClient _httpClient;

        public MoneybirdClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<T> GetAsync<T>(string path)
            where T : class
        {
            var response = await _httpClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream);
        }
    }
}