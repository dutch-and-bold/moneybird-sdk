using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenStore
    {
        /// <summary>
        /// Stores the token to a backend.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StoreTokenAsync(AccessToken accessToken, CancellationToken cancellationToken = default);
    }
}