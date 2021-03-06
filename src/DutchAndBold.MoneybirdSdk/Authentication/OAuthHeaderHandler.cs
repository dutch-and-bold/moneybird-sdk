using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;

namespace DutchAndBold.MoneybirdSdk.Authentication
{
    public class OAuthHeaderHandler : DelegatingHandler
    {
        private readonly IAccessTokenAccessor _accessTokenAccessor;
        private readonly IAccessTokenStore _accessTokenStore;
        private readonly IAccessTokenRefresher _accessTokenRefresher;

        public OAuthHeaderHandler(
            IAccessTokenAccessor accessTokenAccessor,
            IAccessTokenStore accessTokenStore,
            IAccessTokenRefresher accessTokenRefresher = null)
        {
            _accessTokenAccessor = accessTokenAccessor ?? throw new ArgumentNullException(nameof(accessTokenAccessor));
            _accessTokenStore = accessTokenStore ?? throw new ArgumentNullException(nameof(accessTokenStore));
            _accessTokenRefresher = accessTokenRefresher;
        }

        [SuppressMessage("ReSharper", "CA1303")]
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var accessToken = _accessTokenAccessor.AccessToken;

            if (accessToken == null)
            {
                throw new InvalidOperationException("Missing access token.");
            }

            if (accessToken.IsExpired)
            {
                if (_accessTokenRefresher == null)
                {
                    throw new InvalidOperationException(
                        $"Access token is expired and there is no [{nameof(IAccessTokenRefresher)}].");
                }

                accessToken = await _accessTokenRefresher.RefreshAccessToken(
                    accessToken.RefreshToken,
                    cancellationToken);

                await _accessTokenStore.StoreTokenAsync(accessToken, cancellationToken);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Value);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}