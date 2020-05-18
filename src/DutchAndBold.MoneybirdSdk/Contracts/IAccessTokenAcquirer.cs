using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Authentication;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenAcquirer
    {
        /// <summary>
        /// Acquires fresh access token from authority (oauth).
        /// </summary>
        /// <param name="authorizationCode">One time authorization code generated for scoped administration access.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Brand new access token.</returns>
        public Task<AccessToken> AcquireAccessTokenAsync(
            string authorizationCode,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the uri that can be used to start the authentication.
        /// When the users is logged in and accepts the scopes it will be:
        /// 
        /// * Normal: Redirected to the given redirect uri with the token.
        /// * M2M: Given an string authentication code they can paste somewhere in your application.
        /// </summary>
        /// <returns>The uri for the end user.</returns>
        public Uri GetAuthenticationUrl(IEnumerable<MoneybirdOAuthScope> scopes = default);
    }
}