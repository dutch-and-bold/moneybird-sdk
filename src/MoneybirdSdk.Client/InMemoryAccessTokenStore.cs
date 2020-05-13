using System.Threading;
using System.Threading.Tasks;
using MoneybirdSdk.Client.Contracts;
using MoneybirdSdk.Client.Models;

namespace MoneybirdSdk.Client
{
    public class InMemoryAccessTokenStore : IAccessTokenAccessor, IAccessTokenStore
    {
        public Task StoreTokenAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
        {
            AccessToken = accessToken;
            return Task.CompletedTask;
        }

        public AccessToken AccessToken { get; private set; }
    }
}