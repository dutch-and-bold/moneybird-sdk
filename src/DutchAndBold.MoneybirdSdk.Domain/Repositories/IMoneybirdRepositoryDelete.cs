using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Domain.Models;

namespace DutchAndBold.MoneybirdSdk.Domain.Repositories
{
    /// <summary>
    /// Moneybird repository for deletes.
    /// </summary>
    /// <typeparam name="TMoneybirdEntity"></typeparam>
    public interface IMoneybirdRepositoryDelete<TMoneybirdEntity>
        where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Deletes one entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(TMoneybirdEntity entity, CancellationToken cancellationToken = default);
    }
}