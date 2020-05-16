using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Query;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    public interface IMoneybirdRepositoryRead<TResource, TQuery>
        where TResource : IMoneybirdEntity
        where TQuery : IMoneybirdQuery
    {
        Task<IEnumerable<TResource>> GetAsync(
            Action<TQuery> action,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TResource>> GetAsync(CancellationToken cancellationToken = default);
    }

    public interface IMoneybirdRepositoryRead<TResource> : IMoneybirdRepositoryRead<TResource, MoneybirdQuery>
        where TResource : IMoneybirdEntity
    {
    }
}