using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenRefresher
    {
        public Task<AccessToken> RefreshAccessToken(string refreshToken, CancellationToken cancellationToken = default);
    }
}