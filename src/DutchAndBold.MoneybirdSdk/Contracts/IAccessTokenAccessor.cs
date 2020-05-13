using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenAccessor
    {
        AccessToken AccessToken { get; }
    }
}