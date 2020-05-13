using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MoneybirdSdk.Client.Contracts;

namespace MoneybirdSdk.Client
{
    public class OAuthHeaderHandler : DelegatingHandler
    {
        private readonly IAccessTokenAccessor _accessTokenAccessor;
        private readonly IAccessTokenAcquirer _accessTokenAcquirer;
        private readonly IAccessTokenStore _accessTokenStore;

        public OAuthHeaderHandler(
            IAccessTokenAccessor accessTokenAccessor,
            IAccessTokenAcquirer accessTokenAcquirer,
            IAccessTokenStore accessTokenStore)
        {
            _accessTokenAccessor = accessTokenAccessor;
            _accessTokenAcquirer = accessTokenAcquirer;
            _accessTokenStore = accessTokenStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var accessToken = _accessTokenAccessor.AccessToken;

            if (accessToken == null || accessToken.IsExpired)
            {
                accessToken = await _accessTokenAcquirer.AcquireAccessTokenAsync();
                await _accessTokenStore.StoreTokenAsync(accessToken);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Value);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}