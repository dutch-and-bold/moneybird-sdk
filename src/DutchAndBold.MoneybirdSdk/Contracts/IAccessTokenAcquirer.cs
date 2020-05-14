using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenAcquirer
    {
        public Task<AccessToken> AcquireAccessTokenAsync(
            string authorizationCode,
            CancellationToken cancellationToken = default);
    }
}