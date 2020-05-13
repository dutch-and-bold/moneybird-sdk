using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneybirdSdk.Client.Contracts;
using MoneybirdSdk.Client.Models;

namespace MoneybirdSdk.Client
{
    public class MachineToMachineOAuth2Client : IAccessTokenAcquirer
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authorizationCode;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();

        public MachineToMachineOAuth2Client(
            HttpClient httpClient,
            string clientId,
            string clientSecret,
            string authorizationCode)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _authorizationCode = authorizationCode;
            _jsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
        }

        public async Task<AccessToken> AcquireAccessTokenAsync()
        {
            using var postBody = new StringContent(
                $"client_id={_clientId}&client_secret={_clientSecret}&code={_authorizationCode}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&grant_type=authorization_code",
                Encoding.Default,
                "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync(
                "token",
                postBody);

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var accessToken =
                await JsonSerializer.DeserializeAsync<AccessToken>(responseStream, _jsonSerializerOptions);

            return accessToken;
        }
    }
}