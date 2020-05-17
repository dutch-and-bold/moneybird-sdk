using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenRefresher
    {
        /// <summary>
        /// Refreshes the token (oauth).
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccessToken> RefreshAccessToken(string refreshToken, CancellationToken cancellationToken = default);
    }
}