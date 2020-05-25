using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    /// <summary>
    /// Moneybird Repository interface for updating entities.
    /// </summary>
    /// <typeparam name="TMoneybirdEntity"></typeparam>
    public interface IMoneybirdRepositoryUpdate<TMoneybirdEntity>
        where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Updates a Moneybird entity.
        /// </summary>
        /// <param name="entity">Moneybird entity to update.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TMoneybirdEntity> UpdateAsync(
            TMoneybirdEntity entity,
            CancellationToken cancellationToken = default);
    }
}