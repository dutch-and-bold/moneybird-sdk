using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    public interface IMoneybirdRepositoryRead<TResource>
        where TResource : MoneybirdEntityBase
    {
        Task<IEnumerable<TResource>> GetAsync(CancellationToken cancellationToken = default);
    }
}