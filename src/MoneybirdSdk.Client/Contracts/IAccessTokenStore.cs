using System.Threading;
using System.Threading.Tasks;
using MoneybirdSdk.Client.Models;

namespace MoneybirdSdk.Client.Contracts
{
    public interface IAccessTokenStore
    {
        Task StoreTokenAsync(AccessToken accessToken, CancellationToken cancellationToken = default);
    }
}