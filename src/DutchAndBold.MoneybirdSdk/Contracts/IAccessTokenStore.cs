using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenStore
    {
        Task StoreTokenAsync(AccessToken accessToken, CancellationToken cancellationToken = default);
    }
}