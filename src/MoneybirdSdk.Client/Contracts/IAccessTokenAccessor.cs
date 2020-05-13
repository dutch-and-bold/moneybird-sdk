using MoneybirdSdk.Client.Models;

namespace MoneybirdSdk.Client.Contracts
{
    public interface IAccessTokenAccessor
    {
        AccessToken AccessToken { get; }
    }
}