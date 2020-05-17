using System.Threading;
using System.Threading.Tasks;
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
        /// <returns></returns>
        public Task<AccessToken> AcquireAccessTokenAsync(
            string authorizationCode,
            CancellationToken cancellationToken = default);
    }
}