using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Extensions;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Authentication
{
    public class OAuth2Client : IAccessTokenAcquirer, IAccessTokenRefresher
    {
        private readonly HttpClient _httpClient;

        private readonly string _clientId;

        private readonly string _clientSecret;

        private readonly Uri _redirectTo;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();

        public OAuth2Client(
            HttpClient httpClient,
            string clientId,
            string clientSecret,
            Uri redirectUri)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectTo = redirectUri;
            _jsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
        }

        /// <inheritdoc cref="IAccessTokenAcquirer"/>
        public Task<AccessToken> AcquireAccessTokenAsync(
            string authorizationCode,
            CancellationToken cancellationToken = default)
        {
            return MakeAccessTokenRequest(
                $"client_id={_clientId}" +
                $"&client_secret={_clientSecret}" +
                $"&code={authorizationCode}" +
                $"&redirect_uri={_redirectTo}" +
                "&grant_type=authorization_code",
                cancellationToken);
        }

        /// <inheritdoc cref="IAccessTokenRefresher"/>
        public Task<AccessToken> RefreshAccessToken(string refreshToken, CancellationToken cancellationToken = default)
        {
            return MakeAccessTokenRequest(
                $"client_id={_clientId}" +
                $"&client_secret={_clientSecret}" +
                $"&refresh_token={refreshToken}" +
                "&grant_type=refresh_token",
                cancellationToken);
        }

        /// <inheritdoc cref="IAccessTokenAcquirer"/>
        public Uri GetAuthenticationUrl(IEnumerable<MoneybirdOAuthScope> scopes = default)
        {
            var scopeString = "";

            scopes = scopes?.ToList();

            if (scopes != null && scopes.Any())
            {
                scopeString = "&scope=" +
                              string.Join(
                                  ' ',
                                  scopes.Select(o => o.ToString().PascalToSnakeCase()));
            }

            return new Uri(
                _httpClient.BaseAddress,
                $"authorize?client_id={_clientId}&redirect_uri={_redirectTo}&response_type=code{scopeString}");
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