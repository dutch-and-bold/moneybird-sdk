using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    /// <summary>
    /// Moneybird Repository interface for storing new entities.
    /// </summary>
    /// <typeparam name="TMoneybirdEntity"></typeparam>
    public interface IMoneybirdRepositoryCreate<TMoneybirdEntity>
        where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Stores a new entity.
        /// </summary>
        /// <param name="entity">New entity to store.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TMoneybirdEntity> StoreAsync(
            TMoneybirdEntity entity,
            CancellationToken cancellationToken = default);
    }
}