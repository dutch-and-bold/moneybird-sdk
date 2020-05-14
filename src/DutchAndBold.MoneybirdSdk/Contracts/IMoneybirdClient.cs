using System.Threading;
using System.Threading.Tasks;

namespace DutchAndBold.MoneybirdSdk.Contracts
{
    public interface IMoneybirdClient
    {
        public Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
            where T : class;
    }
}