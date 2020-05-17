using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Query;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    /// <summary>
    /// Moneybird Repository interface for retrieving entities.
    /// </summary>
    /// <typeparam name="TMoneybirdEntity"></typeparam>
    /// <typeparam name="TMoneybirdQuery"></typeparam>
    public interface IMoneybirdRepositoryRead<TMoneybirdEntity, TMoneybirdQuery>
        where TMoneybirdEntity : IMoneybirdEntity
        where TMoneybirdQuery : IMoneybirdQuery
    {
        /// <summary>
        /// Gets entities.
        /// </summary>
        /// <param name="action">Is given an empty <see cref="TQuery"/>.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TMoneybirdEntity>> GetAsync(
            Action<TMoneybirdQuery> action = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets entities with the <see cref="TMoneybirdQuery"/> defaults.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TMoneybirdEntity>> GetAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Moneybird Repository interface for storing new entities.
    /// Uses a standard <see cref="MoneybirdQuery"/>.
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public interface IMoneybirdRepositoryRead<TResource> : IMoneybirdRepositoryRead<TResource, MoneybirdQuery>
        where TResource : IMoneybirdEntity
    {
    }
}