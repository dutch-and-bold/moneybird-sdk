using System.Threading.Tasks;
using MoneybirdSdk.Client.Models;

namespace MoneybirdSdk.Client.Contracts
{
    public interface IAccessTokenAcquirer
    {
        public Task<AccessToken> AcquireAccessTokenAsync();
    }
}