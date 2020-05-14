using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk
{
    public class MachineToMachineOAuth2Client : IAccessTokenAcquirer, IAccessTokenRefresher
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();

        public MachineToMachineOAuth2Client(
            HttpClient httpClient,
            string clientId,
            string clientSecret)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _jsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
        }

        public Task<AccessToken> AcquireAccessTokenAsync(
            string authorizationCode,
            CancellationToken cancellationToken = default)
        {
            return MakeAccessTokenRequest(
                $"client_id={_clientId}" +
                $"&client_secret={_clientSecret}" +
                $"&code={authorizationCode}" +
                "&redirect_uri=urn:ietf:wg:oauth:2.0:oob" +
                "&grant_type=authorization_code",
                cancellationToken);
        }

        public Task<AccessToken> RefreshAccessToken(string refreshToken, CancellationToken cancellationToken = default)
        {
            return MakeAccessTokenRequest(
                $"client_id={_clientId}" +
                $"&client_secret={_clientSecret}" +
                $"&refresh_token={refreshToken}" +
                "&grant_type=refresh_token",
                cancellationToken);
        }

        private async Task<AccessToken> MakeAccessTokenRequest(
            string bodyString,
            CancellationToken cancellationToken = default)
        {
            using var postBody = new StringContent(
                bodyString,
                Encoding.Default,
                "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync(
                "token",
                postBody,
                cancellationToken);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var accessToken =
                await JsonSerializer.DeserializeAsync<AccessToken>(
                    responseStream,
                    _jsonSerializerOptions,
                    cancellationToken);

            return accessToken;
        }
    }
}