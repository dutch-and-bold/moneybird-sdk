using System.Threading;
using System.Threading.Tasks;
using DutchAndBold.MoneybirdSdk.Contracts;
using DutchAndBold.MoneybirdSdk.Domain.Models;
using DutchAndBold.MoneybirdSdk.Domain.Repositories;

namespace DutchAndBold.MoneybirdSdk.Repositories
{
    public class MoneybirdRepositoryDelete<TMoneybirdEntity>
        : MoneybirdRepositoryBase, IMoneybirdRepositoryDelete<TMoneybirdEntity>
        where TMoneybirdEntity : class, IMoneybirdEntity
    {
        public MoneybirdRepositoryDelete(
            string apiPath,
            IMoneybirdClient moneybirdClient,
            IMoneybirdAdministrationAccessor administrationAccessor = default)
            : base(apiPath, moneybirdClient, administrationAccessor)
        {
        }

        public Task DeleteAsync(TMoneybirdEntity entity, CancellationToken cancellationToken = default)
        {
            return Client.DeleteAsync(GetApiPath(entity), cancellationToken);
        }
    }
}