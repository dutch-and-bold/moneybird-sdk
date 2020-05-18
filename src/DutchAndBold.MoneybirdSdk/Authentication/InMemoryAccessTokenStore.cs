using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Authentication
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