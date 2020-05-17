using DutchAndBold.MoneybirdSdk.Models;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IAccessTokenAccessor
    {
        /// <summary>
        /// Gets access token from a backend.
        /// </summary>
        AccessToken AccessToken { get; }
    }
}